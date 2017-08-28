using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NJBGoogleMapV2;

namespace NJBGoogleMapV2_Tester
{
    public partial class Form1 : Form
    {
        MapLatLng LastRightClickPosition;
        string LastMarkerRightClick;
        string LastHouseRightClick;
        string LastPolygonRightClick;
        int Indexing = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void njbGoogleMap1_MapLoadError(object sender, EventArgs e)
        {
            
        }

        private void njbGoogleMap1_MapLoadSuccess(object sender, EventArgs e)
        {
            njbGoogleMap1.SetMapCenter(new MapLatLng(10.730778438271534, 122.55025863647461));
            njbGoogleMap1.SetMapZoom(15);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           MessageBox.Show(njbGoogleMap1.GetMapCenter().ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.SetMapCenter(new MapLatLng(10.725549947941222, 122.54759788513184));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.GetMapType());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.SetMapType(MapType.Hybrid);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.GetMapZoom().ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.SetMapZoom(16);
        }

        private void njbGoogleMap1_MapClick(object sender, MapClickEventArgs e)
        {
            
        }

        private void njbGoogleMap1_MapRightClick(object sender, MapClickEventArgs e)
        {
            LastRightClickPosition = e.LatLng;
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void createMarkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Indexing++;
            njbGoogleMap1.CreateMarker(Indexing.ToString(), "Marker " + Indexing, LastRightClickPosition, false);
        }

        private void njbGoogleMap1_MapMarkerClick(object sender, MapItemClickEventArgs e)
        {
            MessageBox.Show("Marker " + e.ID + " Clicked");
        }

        private void njbGoogleMap1_MapMarkerRightClick(object sender, MapItemClickEventArgs e)
        {
            LastMarkerRightClick = e.ID;
            MarkerMenu.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.MarkerExists("1").ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.MarkerVisible("1").ToString());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.HideMarker("1");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.ShowMarker("1");
        }

        private void getPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.GetMarkerPosition(LastMarkerRightClick).ToString());
        }

        private void setMarkerPositionIDLatLngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.SetMarkerPosition(LastMarkerRightClick, new MapLatLng(10.71572520152726, 122.55489349365234));
        }

        private void getMarkerTitleIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.GetMarkerTitle(LastMarkerRightClick));
        }

        private void setMarkerTitleIDTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.SetMarkerTitle(LastMarkerRightClick, "New Title!");
        }

        private void deleteMarkerIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.DeleteMarker(LastMarkerRightClick);
        }

        private void deleteAllMarkersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            njbGoogleMap1.DeleteAllMarkers();
        }

        private void getMarkerDraggableIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.GetMarkerDraggable(LastMarkerRightClick).ToString());
        }

        private void setMarkerDraggableIDDraggableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (njbGoogleMap1.GetMarkerDraggable(LastMarkerRightClick))
                njbGoogleMap1.SetMarkerDraggable(LastMarkerRightClick, false);
            else
                njbGoogleMap1.SetMarkerDraggable(LastMarkerRightClick, true);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            foreach (string id in njbGoogleMap1.GetMarkerIDList())
            {
                MessageBox.Show(id);
            }
        }

        private void createHouseIDTtitleLatLngLabelColorDraggableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Indexing++;
            njbGoogleMap1.CreateHouse(Indexing.ToString(), "House " + Indexing.ToString(), LastRightClickPosition, ' ', new MapHouseColor("black", "white"), false);
        }

        private void njbGoogleMap1_MapHouseClick(object sender, MapItemClickEventArgs e)
        {
            MessageBox.Show("House " + e.ID + " Clicked");
        }

        private void njbGoogleMap1_MapHouseRightClick(object sender, MapItemClickEventArgs e)
        {
            LastHouseRightClick = e.ID;
            HouseMenu.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.FitHousesToMap();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.HouseExists("1").ToString());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.HouseVisible("1").ToString());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.HideHouse("1");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.ShowHouse("1");
        }

        private void getHousePositionIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.GetHousePosition(LastHouseRightClick).ToString());
        }

        private void setHousePositionIDLatLngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.SetHousePosition(LastHouseRightClick, new MapLatLng(10.71572520152726, 122.55489349365234));
        }

        private void getHouseTitleIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.GetHouseTitle(LastHouseRightClick));
        }

        private void setHouseTitleIDTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.SetHouseTitle(LastHouseRightClick, "This is new title");
        }

        private void getToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.GetHouseLabel(LastHouseRightClick).ToString());
        }

        private void setHouseLabelIDLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.SetHouseLabel(LastHouseRightClick, 'H');
        }

        private void getHouseColorIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.GetHouseColor(LastHouseRightClick).ToString());
        }

        private void setHouseColorIDColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string color = MapExtraTools.PickColor();

            njbGoogleMap1.SetHouseColor(LastHouseRightClick, new MapHouseColor(color, "white"));
        }

        private void deleteHouseIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.DeleteHouse(LastHouseRightClick);
        }

        private void deleteAllHousesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.DeleteAllHouses();
        }

        private void getHouseDraggableIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.GetHouseDraggable(LastHouseRightClick).ToString());
        }

        private void setHouseDraggableIDDraggableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (njbGoogleMap1.GetHouseDraggable(LastHouseRightClick))
                njbGoogleMap1.SetHouseDraggable(LastHouseRightClick, false);
            else
                njbGoogleMap1.SetHouseDraggable(LastHouseRightClick, true);
        }

        private void houseSelectedIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.HouseSelected(LastHouseRightClick).ToString());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.GetSelectMode().ToString());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (njbGoogleMap1.GetSelectMode())
                njbGoogleMap1.SetSelectMode(false);
            else
                njbGoogleMap1.SetSelectMode(true);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.DeselectHouse("1");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.SelectHouse("1");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            foreach (string id in njbGoogleMap1.GetHouseIDList())
            {
                MessageBox.Show("House" + id);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            foreach (string id in njbGoogleMap1.GetSelectedHouseIDList())
            {
                MessageBox.Show("House" + id);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.GetDrawingMode().ToString());
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (njbGoogleMap1.GetDrawingMode())
                njbGoogleMap1.SetDrawingMode(false);
            else
                njbGoogleMap1.SetDrawingMode(true);
        }

        private void njbGoogleMap1_MapDrawingComplete(object sender, MapDrawingCompleteEventArgs e)
        {

            Indexing++;
            string color = MapExtraTools.PickColor();

            njbGoogleMap1.CreatePolygon(Indexing.ToString(), e.Path, color, .5, true);
        }

        private void njbGoogleMap1_MapPolygonRightClick(object sender, MapItemClickEventArgs e)
        {
            LastPolygonRightClick = e.ID;
            PolygonMenu.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void njbGoogleMap1_MapPolygonClick(object sender, MapItemClickEventArgs e)
        {
            MessageBox.Show("Polygon " + e.ID + " Clicked");
        }

        private void button28_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.PolygonExists("1").ToString());
        }

        private void button27_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.PolygonVisible("1").ToString());
        }

        private void button26_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.HidePolygon("1");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.ShowPolygon("1");
        }

        private void getPolygonPathIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            foreach (MapLatLng LatLng in njbGoogleMap1.GetPolygonPath(LastPolygonRightClick))
                path += LatLng.ToString() + "\n";
            MessageBox.Show(path);
        }

        private void setPolygonPathIDPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapLatLng[] path = {
                                   new MapLatLng(10.730778438271534, 122.55025863647461),
                                   new MapLatLng(10.72765822104726, 122.5521469116211),
                                   new MapLatLng(10.731073592287958, 122.55849838256836),
                                   new MapLatLng(10.733139662334343, 122.55364894866943)
                               };
            njbGoogleMap1.SetPolygonPath(LastPolygonRightClick, path);
        }

        private void getPolygonColorIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.GetPolygonColor(LastPolygonRightClick));
        }

        private void setPolygonColorIDColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string color = MapExtraTools.PickColor();

            njbGoogleMap1.SetPolygonColor(LastPolygonRightClick, color);
        }

        private void getPolygonOpacityIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.GetPolygonOpacity(LastPolygonRightClick).ToString());
        }

        private void setPolygonOpacityIDOpacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.SetPolygonOpacity(LastPolygonRightClick, .2);
        }

        private void getPolygonClickableIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.GetPolygonClickable(LastPolygonRightClick).ToString());
        }

        private void setPolygonClickableIDClickableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (njbGoogleMap1.GetPolygonClickable(LastPolygonRightClick))
                njbGoogleMap1.SetPolygonClickable(LastPolygonRightClick, false);
            else
                njbGoogleMap1.SetPolygonClickable(LastPolygonRightClick, true);
        }

        private void getPolygonEditableIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.GetPolygonEditable(LastPolygonRightClick).ToString());
        }

        private void setPolygonEditableIDEditableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (njbGoogleMap1.GetPolygonEditable(LastPolygonRightClick))
                njbGoogleMap1.SetPolygonEditable(LastPolygonRightClick, false);
            else
                njbGoogleMap1.SetPolygonEditable(LastPolygonRightClick, true);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.DeleteAllPolygons();
        }

        private void deletePolygonIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.DeletePolygon(LastPolygonRightClick);
        }

        private void polygonContainsLocationIDLatLngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(njbGoogleMap1.PolygonContainsLocation(LastPolygonRightClick, new MapLatLng(10, 122)).ToString());
        }

        private void getHousesInPolygonIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ids = "";
            foreach (string id in njbGoogleMap1.GetHousesInPolygon(LastPolygonRightClick))
            {
                ids += id + "\n";
            }
            MessageBox.Show(ids);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            string ids = "";
            foreach (string id in njbGoogleMap1.GetPolygonIDList())
            {
                ids += id + "\n";
            }
            MessageBox.Show(ids);
        }

        private void getMarkerIconIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void getMarkerIconIDToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string icon = njbGoogleMap1.GetMarkerIcon(LastMarkerRightClick);
            MessageBox.Show(icon);
        }

        private void setMarkerIconIDIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            njbGoogleMap1.SetMarkerIcon(LastMarkerRightClick, "");
        }
    }
}
