

using AccountingSoftware;
using Конфа = НоваКонфігурація_1_0;
using Довідники = НоваКонфігурація_1_0.Довідники;
using System.ComponentModel;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            RecordsBindingList = new BindingList<Записи>();
            dataGridViewRecords.DataSource = RecordsBindingList;

            dataGridViewRecords.Columns["ID"].Visible = false;
            dataGridViewRecords.Columns["Назва"].Width = 300;
            dataGridViewRecords.Columns["Код"].Width = 80;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Exception exception;
            string pathToConfa = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Confa.xml");

            Конфа.Config.Kernel = new Kernel();
            bool flagOpen = Конфа.Config.Kernel.Open(pathToConfa, "localhost", "postgres ", "1", 5432, "test", out exception);

            if (!flagOpen)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            LoadRecords();
        }

        private BindingList<Записи> RecordsBindingList { get; set; }

        private void LoadRecords()
        {
            RecordsBindingList.Clear();

            Довідники.Номенклатура_Select НоменклатураВибірка = new Довідники.Номенклатура_Select();
            НоменклатураВибірка.QuerySelect.Field.AddRange(
                new string[] 
                { 
                    Довідники.Номенклатура_Const.Код,
                    Довідники.Номенклатура_Const.Назва,
                    Довідники.Номенклатура_Const.код2
                }
            );

            //НоменклатураВибірка.QuerySelect.Order.Add(Довідники.Номенклатура_Const.Код, SelectOrder.ASC);

            НоменклатураВибірка.Select();

            while (НоменклатураВибірка.MoveNext())
            {
                Довідники.Номенклатура_Pointer НоменклатураВказівник = НоменклатураВибірка.Current;

                RecordsBindingList.Add(new Записи
                {
                    ID = НоменклатураВказівник.UnigueID.ToString(),
                    Код = НоменклатураВказівник.Fields[Довідники.Номенклатура_Const.Код].ToString(),
                    Назва = НоменклатураВказівник.Fields[Довідники.Номенклатура_Const.Назва].ToString(),
                    Код2 = НоменклатураВказівник.Fields[Довідники.Номенклатура_Const.код2].ToString()
                });
            }
        }

        private class Записи
        {
            public string ID { get; set; }
            public string Код { get; set; }
            public string Назва { get; set; }
            public string Код2 { get; set; }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            Довідники.Номенклатура_Objest Номенклатура = new Довідники.Номенклатура_Objest();
            Номенклатура.New();
            Номенклатура.Код = "0001";
            Номенклатура.Назва = "Товар А";
            Номенклатура.код2 = "555";
            Номенклатура.Save();

            LoadRecords();
        }

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            if (dataGridViewRecords.SelectedRows.Count != 0 &&
                MessageBox.Show("Копіювати записи?", "Повідомлення", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridViewRecords.SelectedRows.Count; i++)
                {
                    DataGridViewRow row = dataGridViewRecords.SelectedRows[i];
                    string uid = row.Cells["ID"].Value.ToString();

                    Довідники.Номенклатура_Objest номенклатура_Objest = new Довідники.Номенклатура_Objest();
                    if (номенклатура_Objest.Read(new UnigueID(uid)))
                    {
                        Довідники.Номенклатура_Objest номенклатура_Objest_Новий = номенклатура_Objest.Copy();
                        номенклатура_Objest_Новий.Назва = номенклатура_Objest_Новий.Назва + " - Копія";
                        номенклатура_Objest_Новий.Код = "0002";
                        номенклатура_Objest_Новий.Save();
                    }
                    else
                    {
                        MessageBox.Show("Error read");
                        break;
                    }
                }

                LoadRecords();
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewRecords.SelectedRows.Count != 0 &&
                MessageBox.Show("Видалити записи?", "Повідомлення", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridViewRecords.SelectedRows.Count; i++)
                {
                    DataGridViewRow row = dataGridViewRecords.SelectedRows[i];
                    string uid = row.Cells["ID"].Value.ToString();

                    Довідники.Номенклатура_Objest номенклатура_Objest = new Довідники.Номенклатура_Objest();
                    if (номенклатура_Objest.Read(new UnigueID(uid)))
                    {
                        номенклатура_Objest.Delete();
                    }
                    else
                    {
                        MessageBox.Show("Error read");
                        break;
                    }
                }

                LoadRecords();
            }
        }
    }
}