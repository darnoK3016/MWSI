using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace MWSI
{
    public partial class MainForm : Form
    {
        private string tempMWSIPath; //sciezka do temp (cache)
        private List<MapLayer> mapLayersInfo = new List<MapLayer>(); // Lista z obiektami warstw map <MapLayer>
        private PictureBox mapLayers; // PictureBox do wszystkich warstw
        private MouseEvents me; // Mouse Event handler
        private bool changePosition = false; // flaga potrzebna podczas zmiany pozycji warstwy na listboxie

        public MainForm()
        {
            try
            {
                // tworzenie pliku temp (cache)
                tempMWSIPath = Path.Combine(Path.GetTempPath(), "MWSI");
                if (Directory.Exists(tempMWSIPath))
                {
                    Directory.Delete(tempMWSIPath, true);
                }
                Directory.CreateDirectory(tempMWSIPath);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            InitializeComponent();
        }

        private void CADRGToolStripMenuItem_Click(object sender, EventArgs e) //funkcja wczytywania z pliku
        {
            try
            {
                using (var ofp = new OpenFileDialog())
                {
                    ofp.Multiselect = false;
                    ofp.Filter = @"png|*.png";
                    ofp.RestoreDirectory = true;
                    if (ofp.ShowDialog() == DialogResult.OK)
                    {
                        // Otwieranie
                        var layer = new PictureBox();
                        string name;
                        layer.Image = new Bitmap(ofp.FileName);
                        name = ofp.FileName;
                        string[] n = name.Split('\\');
                        name = n[n.Length - 1];

                        //tworzenie sciezki do pliku 
                        var tempLayerPath = Path.Combine(tempMWSIPath, name);

                        n = name.Split('.');
                        name = n[0];
                        //zapisywanie pliku uzywajac nowej sciezki
                        if (!File.Exists(tempLayerPath))
                        {
                            layer.Image.Save(tempLayerPath, ImageFormat.Png);
                            layer.Dispose();

                            var newLayer = new MapLayer(tempLayerPath, LayersPanel.Size);
                            mapLayersInfo.Add(newLayer);
                            CheckedListBoxMaps.Items.Add(name, true);
                        }
                        else
                        {
                            MessageBox.Show($"Map layer with name \"{name}\" is already exist." , "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ofp.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MouseHandler() //funkcja do obslugi mouse eventow
        {
            try
            {
                me = new MouseEvents(mapLayers, LayersPanel.Size);
                MouseWheel += new MouseEventHandler(me.Maps_Zoom); // Myszke przechwytuje list box i jak nie dziala trzeba odswiezyc (ButtonRefresh)
                mapLayers.MouseEnter += new EventHandler(me.Maps_Enter);
                mapLayers.MouseLeave += new EventHandler(me.Maps_Left);
                mapLayers.MouseDown += new MouseEventHandler(me.Maps_Down);
                mapLayers.MouseUp += new MouseEventHandler(me.Maps_Up);
                mapLayers.MouseMove += new MouseEventHandler(me.Maps_Move);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static Bitmap ChangeOpacity(Image originalImage, double opacity) //zmiana przezroczystosci 
        {
            if ((originalImage.PixelFormat & PixelFormat.Indexed) == PixelFormat.Indexed) // sprawdzanie czy nowy obraz bedzie sie roznil od starego
            {
                return (Bitmap)originalImage;
            }

            Bitmap bmp = (Bitmap)originalImage.Clone(); //klonowanie oryginalnego bitmapu

            PixelFormat pxf = PixelFormat.Format32bppArgb; //ustawienie formatu pixeli

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, pxf); //blokowanie bitow potrzebne do optymalizacji

            //tworzenie potrzebnych zmiennych do zmiany przezroczystosci
            IntPtr ptr = bmpData.Scan0;
            int bytesPerPixel = 4;
            int numBytes = bmp.Width * bmp.Height * bytesPerPixel;
            byte[] argbValues = new byte[numBytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, argbValues, 0, numBytes);

            for (int counter = 0; counter < argbValues.Length; counter += bytesPerPixel)
            {

                if (argbValues[counter + bytesPerPixel - 1] == 0)
                    continue;

                int pos = 0;
                pos++;
                pos++;
                pos++;

                argbValues[counter + pos] = (byte)(argbValues[counter + pos] * opacity);
            } //petla zmieniajaca warstwy alpha dla pixeli
            System.Runtime.InteropServices.Marshal.Copy(argbValues, 0, ptr, numBytes);
            bmp.UnlockBits(bmpData); //odblokowanie bitow
            return bmp; //zwrocenie nowego obrazu
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                LayersPanel.Size = new Size(Width - 180, Height - 63);
                if (mapLayers != null)
                    mapLayers.Size = LayersPanel.Size;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        } //obsluga eventu podczas zmiany wielkosci okna aplikacji
        private void CheckedListBoxMaps_ItemCheck(object sender, ItemCheckEventArgs e)//obsluga eventu podczas zaznaczania warstwy
        {
            if (!changePosition) //sprawdzenie czy zaznaczona warstwa zmienia polozenie na liscie, poniewaz w momencie zmiany nastepuje uruchomienie eventu lecz nie aktywnosc warstwy niepowinna sie wtedy zmienic
            {
                mapLayersInfo[e.Index].ChangeActive(); // zmiana aktywnosci odznaczonej warstwy
                Panel1Refresh();
            }
        }

        private void CheckedListBoxMaps_SelectedIndexChanged(object sender, EventArgs e) //obsluga eventu podczas zmiany zaznaczonej warstwy na liscie
        {
            // jezeli zaznaczamy warstwe to wlaczamy przyciski i suwak do przezroczystosci
            var selected = CheckedListBoxMaps.SelectedIndex;
            OpacityScrollBar.Enabled = true;
            ButtonUp.Enabled = true;
            ButtonDown.Enabled = true;
            OpacityLabel.Show();
            if (selected >= 0)
            {
                //obsluga layeru z wartoscia przezroczystosci
                OpacityScrollBar.Value = (int)(mapLayersInfo[selected].GetOpacity() * 100);
                OpacityLabel.Text = $"Opacity: {OpacityScrollBar.Value}%";

            }
        }

        private void Panel1Refresh() //funkcja do odswiezania panelu
        {
            try
            {
                int count = 0; // liczba niewykorzystanych ale aktywnych warstw
                foreach (MapLayer activeLayers in mapLayersInfo) //szukanie aktywnych warstw
                {
                    if (activeLayers.GetActive()) count++;
                }

                //1 szukanie pierwszej aktywnej niewykorzystanej warstwy;

                if (count > 0) // jesli jakas jest aktywna to
                {
                    int index = 0; // poczatek szukania aktywnej warstwy
                    for (index = 0; index < mapLayersInfo.Count; index++) // szukanie pierwszej aktywnej warstwy
                    {
                        if (mapLayersInfo[index].GetActive()) //jesli warstwa i jest pierwsza napotkana 
                        {
                            mapLayers = mapLayersInfo[index].GetLayer(); // staje sie nowa podstawowa warstwa
                            double currentOpacity = mapLayersInfo[index].GetOpacity();
                            if (currentOpacity < 1)
                            {
                                mapLayers.Image = ChangeOpacity(mapLayers.Image, currentOpacity);
                            }
                            count--; // zmniejszenie gdyz 1 warstwa zostala juz wykorzystana
                            break;
                        }
                    }
                    index++; // kolejne szukanie zaczyna sie od nastepnej warstwy

                    //szukanie kolejnych aktywnych i laczenie z poprzednimi

                    while (count > 0) //jezeli istnieje wiecej niewykorzystanych ale aktywnych warstw
                    {
                        //  MessageBox.Show("Szukam dalej");
                        if (mapLayersInfo[index].GetActive()) //jezeli warstwa index jest aktywna
                        {
                            //mechanizm laczacy warste aktualna z nowa
                            var newLayer = mapLayersInfo[index];
                            double currentOpacity = newLayer.GetOpacity();

                            Bitmap bmpNew = (Bitmap)newLayer.GetLayer().Image;

                            if (currentOpacity < 1)
                            {
                                bmpNew = ChangeOpacity(newLayer.GetLayer().Image, currentOpacity);
                            }
                            Bitmap bmpOld = new Bitmap(mapLayers.Image);
                            Graphics g = Graphics.FromImage(bmpNew);
                            g.DrawImage(bmpOld, 0, 0, bmpNew.Size.Width, bmpNew.Size.Height);
                            mapLayers.Image = bmpNew;  // nowa podstawowa warsta
                            g.Dispose();
                            count--; //liczba aktywnych -1, bo pozostalych aktywnych warstw jest mniej
                        }
                        index++; // kolejne szukanie zaczyna sie od nastepnej warstwy
                    }
                    LayersPanel.Controls.Clear(); // usuwanie aktualnych warstw z panelu
                    LayersPanel.Controls.Add(mapLayers); //wyswietlenie aktualnych aktywnych warstw
                    MouseHandler(); // utworzenie MouseHandlera dla nowych warstw
                }
                else
                {
                    LayersPanel.Controls.Clear(); // usuwanie aktualnych warstw z panelu

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

 
        private void ButtonUp_Click(object sender, EventArgs e) //obsluga eventu przycisku podczas zmiany polozenia warstwy do gory
        {
            if (CheckedListBoxMaps.SelectedItem != null)
            {
                var selected = CheckedListBoxMaps.SelectedIndex;
                if (selected > 0)
                {
                    var tempLayer = mapLayersInfo[selected - 1];
                    var tempList = CheckedListBoxMaps.Items[selected - 1];
                    if (CheckedListBoxMaps.GetItemChecked(selected - 1 ) !=
                        CheckedListBoxMaps.GetItemChecked(selected))
                    {
                        changePosition = true;
                        CheckedListBoxMaps.SetItemChecked(selected - 1,
                                !CheckedListBoxMaps.GetItemChecked(selected - 1));

                        CheckedListBoxMaps.SetItemChecked(selected,
                            !CheckedListBoxMaps.GetItemChecked(selected));
                        changePosition = false;
                    }
                    mapLayersInfo[selected - 1] = mapLayersInfo[selected];
                    CheckedListBoxMaps.Items[selected - 1] = CheckedListBoxMaps.Items[selected];

                    mapLayersInfo[selected] = tempLayer;
                    CheckedListBoxMaps.Items[selected] = tempList;
                    CheckedListBoxMaps.SelectedIndex = selected - 1;
                    CheckedListBoxMaps.SelectedItem = CheckedListBoxMaps.Items[selected - 1];
                    Panel1Refresh();
                }
            }
        }

        private void ButtonDown_Click(object sender, EventArgs e) //obsluga eventu przycisku podczas zmiany polozenia warstwy do dolu
        {
            if (CheckedListBoxMaps.SelectedItem != null)
            {
                var selected = CheckedListBoxMaps.SelectedIndex;
                if (selected < CheckedListBoxMaps.Items.Count-1)
                {
                    var tempLayer = mapLayersInfo[selected + 1];
                    var tempList = CheckedListBoxMaps.Items[selected + 1];

                    if (CheckedListBoxMaps.GetItemChecked(selected + 1) !=
                        CheckedListBoxMaps.GetItemChecked(selected))
                    {
                        changePosition = true;
                        CheckedListBoxMaps.SetItemChecked(selected + 1,
                              !CheckedListBoxMaps.GetItemChecked(selected + 1));

                        CheckedListBoxMaps.SetItemChecked(selected,
                            !CheckedListBoxMaps.GetItemChecked(selected));
                        changePosition = false;
                    }

                    mapLayersInfo[selected + 1] = mapLayersInfo[selected];
                    CheckedListBoxMaps.Items[selected + 1] = CheckedListBoxMaps.Items[selected];
                    mapLayersInfo[selected] = tempLayer;
                    CheckedListBoxMaps.Items[selected] = tempList;
                    CheckedListBoxMaps.SelectedIndex = selected + 1;
                    CheckedListBoxMaps.SelectedItem = CheckedListBoxMaps.Items[selected + 1];
                    Panel1Refresh();

                }
            }
        }


        private void OpacityScrollBar_ValueChanged(object sender, EventArgs e)
        {
            if (CheckedListBoxMaps.SelectedItem != null)
            {
                var selected = CheckedListBoxMaps.SelectedIndex;
                var value = OpacityScrollBar.Value;
                mapLayersInfo[selected].SetOpacity(value*0.01);
                OpacityLabel.Text = $"Opacity: {OpacityScrollBar.Value}%";
                Panel1Refresh();
            }
        } //obsluga eventu zmiany przezroczystosci warstwy

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        } //obsluga eventu wyjscia z aplikacji za pomoca menu

        private void ButtonRefresh_MouseClick(object sender, MouseEventArgs e) //obsluga eventu przycisku do odswiezania panelu, potrzebne do odbugowania Mouse Handlera
        {
            Panel1Refresh();
        }
    }
}
