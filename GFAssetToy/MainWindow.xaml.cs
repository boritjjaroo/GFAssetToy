using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GFAssetLib;
using System.Collections.ObjectModel;
using GFAssetLib.Object;

namespace GFAssetToy
{
    public class AssetEntry
    {
        public string path { get; set; }
        public string size { get; set; }
    }

    public class AssetObject
    {
        public int index { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string size { get; set; }
        public string path { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IGFLog
    {
        Logger logger;
        ObservableCollection<AssetEntry> entries = null;
        ObservableCollection<AssetObject> objects = null;

        GFAssetLib.AssetBundle assetBundle;
        SerializedFile currentSerializedFile;

        public MainWindow()
        {
            InitializeComponent();
            logger = LogManager.GetCurrentClassLogger();
            GFAssetLib.GFAssetLib.GetInstance().log = this;

            entries = new ObservableCollection<AssetEntry>();
            listViewEntries.ItemsSource = entries;

            objects = new ObservableCollection<AssetObject>();
            listViewObjects.ItemsSource = objects;
            CollectionView viewObjects = (CollectionView)CollectionViewSource.GetDefaultView(listViewObjects.ItemsSource);
            viewObjects.SortDescriptions.Add(new System.ComponentModel.SortDescription("type", System.ComponentModel.ListSortDirection.Ascending));
            viewObjects.SortDescriptions.Add(new System.ComponentModel.SortDescription("name", System.ComponentModel.ListSortDirection.Ascending));
        }

        public void Debug(string msg)
        {
            logger.Debug(msg);
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs eventArgs)
        {
            GFAssetLib.GFAssetLib.GetInstance().LoadGlobalStrings("strings.dat");
        }

        private void OnButtonOpenAssetClick(object sender, RoutedEventArgs eventArgs)
        {
            assetBundle = new GFAssetLib.AssetBundle();
            try
            {
                this.assetBundle.LoadAssetBundle(@"C:\Users\lesiles\source\repos\GFAssetToy\Test\AndroidResConfigData.txt");
                //this.assetBundle.LoadAssetBundle(@"C:\Users\lesiles\source\repos\GFAssetToy\Test\assettexttable.ab");
                //this.assetBundle.LoadAssetBundle(@"C:\Users\lesiles\source\repos\GFAssetToy\Test\live2dnewgungeneralliu5101.ab");
                //this.assetBundle.LoadAssetBundle(@"C:\Users\lesiles\source\repos\GFAssetToy\Test\live2dnewgunkp311103.ab");
                AssetPrettyWriter writer = new AssetPrettyWriter();
                assetBundle.PrettyPrint(writer);
                logger.Debug(writer.ToString());

                foreach (AssetBundleEntry.EntryInfo entryInfo in assetBundle.entry.entries)
                {
                    entries.Add(new AssetEntry { path = entryInfo.path, size = entryInfo.size.ToString("#,##0") });
                }
            }
            catch (Exception e)
            {
                logger.Error(e.ToString());
                logger.Error(e.StackTrace);
            }
        }

        private void OnButtonOpenEntryClick(object sender, RoutedEventArgs eventArgs)
        {
            if (0 <= listViewEntries.SelectedIndex)
                OpenAssetEntry(listViewEntries.SelectedIndex);
        }

        private void OnListViewEntriesDoubleClick(object sender, RoutedEventArgs eventArgs)
        {
            if (0 <= listViewEntries.SelectedIndex)
                OpenAssetEntry(listViewEntries.SelectedIndex);
        }

        private void OnListViewObjectsDoubleClick(object sender, RoutedEventArgs eventArgs)
        {
            if (listViewObjects.SelectedIndex < 0)
                return;

            AssetObject item = (AssetObject)listViewObjects.SelectedItem;
            string path = currentSerializedFile.ExtractObject(item.index);
            MessageBox.Show($"{path} 저장되었습니다.");
        }

        private void OpenAssetEntry(int index)
        {
            currentSerializedFile = assetBundle.LoadSerializedFile(index);
            AssetPrettyWriter writer = new AssetPrettyWriter();
            currentSerializedFile.PrettyPrint(writer);
            logger.Debug(writer.ToString());

            int count = currentSerializedFile.GetObjectCount();
            for (int i = 0; i < count; i++)
            {
                ObjectBase obj = currentSerializedFile.ReadObject(i);
                //logger.Debug($"Object[0] = {obj.GetName()}");
                objects.Add(
                    new AssetObject { 
                        index = i, name = obj.GetName(), 
                        type = obj.GetTypeName(), 
                        size = obj.GetContentsSize().ToString("#,##0"), 
                        path = obj.ContainerPath 
                    });
            }
        }

        private void OnButtonTestClick(object sender, RoutedEventArgs eventArgs)
        {
        }
    }
}
