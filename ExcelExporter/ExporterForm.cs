using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ExcelExporter.BusinessEntity;
using ExcelExporter.DataAccess;

using BL = ExcelExporter.BusinessLogic.DataConnection;
namespace ExcelExporter
{
    public partial class ExporterForm : Form
    {
        public ExporterForm()
        {
            InitializeComponent();
            Text += @" - " + CurrentSettings.ServerName + @"\" + CurrentSettings.Database;
        }
          private string _type = "", _name = "";

        private void ExporterForm_Load(object sender, EventArgs e)
        {
            var objectTypes = General.GetObjectTypes();
            cbObjectTypes.DataSource = objectTypes;
            var objectNames = General.GetObjectNameByTypes("ALL");
            cbObjectNames.DataSource = objectNames;

        }

        private void cbObjectTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var objectNames = General.GetObjectNameByTypes(cbObjectTypes.Text.Split(',')[0]);
            cbObjectNames.DataSource = objectNames;
        }

        private void btnGenerateQueryTable_Click(object sender, EventArgs e)
        {
            _type = cbObjectTypes.Text.Split(',')[0].Trim();
            _name = cbObjectNames.Text;
            rtbSqlQuery.Text = CurrentSettings.GetSqlQueryTable(_type, _name);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var saveFile = new SaveFileDialog();
            saveFile.Filter = @"Excel Files |*.xlsx";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;
            saveFile.FileName = _name + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = saveFile.FileName;

            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text != "")
            {
                if (txtFileName.Text.Contains(":"))
                {
                    if (File.Exists(txtFileName.Text)) File.Delete(txtFileName.Text);
                    var ee = new BusinessEntity.ExcelExporter(ExcelTypeExporter.AutomationUseArray, txtFileName.Text);
                    DateTime dt1 = DateTime.Now;
                    ee.Automation_QueryTable(txtFileName.Text, BL.DefaultConnectionString, rtbSqlQuery.Text);
                    Console.WriteLine(DateTime.Now - dt1);
                    if (chbOpenFile.Checked)
                        Process.Start(txtFileName.Text);
                    else MessageBox.Show("Fajlli u eksportua me sukses");
                }
                else
                {

                    if (File.Exists(txtFileName.Text)) File.Delete(txtFileName.Text);
                    var ee = new BusinessEntity.ExcelExporter(ExcelTypeExporter.AutomationUseArray, txtFileName.Text);
                    DateTime dt1 = DateTime.Now;
                    ee.Automation_QueryTable(txtFileName.Text, BL.DefaultConnectionString, rtbSqlQuery.Text);
                    Console.WriteLine(DateTime.Now - dt1);
                    if (chbOpenFile.Checked)
                        Process.Start(txtFileName.Text);
                    else MessageBox.Show("Fajlli u eksportua me sukses");
                }
            }
            else
                MessageBox.Show("Ju lutem zgjidhni emrin e fajllit the pathin se ku doni ta ruani");
        }
    }
}
