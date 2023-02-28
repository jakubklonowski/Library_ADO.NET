using Library.models;
using Library.repositories;
using Library.services;

namespace Library
{
    public partial class Library : Form
    {
        readonly LibraryService _service;

        public Library()
        {
            InitializeComponent();
            _service = new LibraryService(new LibraryRepository("Data Source=DESKTOP-JH1VST5\\SQLEXPRESS;Initial Catalog=library;User Id=sa;Password=papaja"));
            fetchData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string bookId = (string)comboBoxBook.SelectedItem;
            string clientId = (string)comboBoxClient.SelectedItem;
            string date = DateTime.Now.ToString();
            bool active = true;
            LibraryRequestJoin library = new()
            {
                Library = new()
                {
                    Date = date,
                    Active = active
                },
                Book = new()
                {
                    Id = bookId,
                    Name = "",
                    Author = ""
                },
                Client = new()
                {
                    Id = clientId,
                    Name = ""
                }
            };
            addBorrow(library);
            clearForms();
            fetchData();
        }

        private void buttonMod_Click(object sender, EventArgs e)
        {
            string id = (string)comboBoxId.SelectedItem;
            string idbook = (string)comboBoxBook.SelectedItem;
            string idclient = (string)comboBoxClient.SelectedItem;
            string date = dateTimePicker0.Value.ToString();
            LibraryModelJoin library = new()
            {
                Library = new()
                {
                    Id = id,
                    Date = date,
                    Active = true
                },
                Book = new()
                {
                    Id = idbook,
                    Name = "",
                    Author = ""
                },
                Client = new()
                {
                    Id = idclient,
                    Name = ""
                }
            };
            modBorrow(library);
            clearForms();
            fetchData();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            string id = (string)comboBoxId.SelectedItem;
            LibraryResponse libraryResponse = new LibraryResponse()
            {
                Id = id,
            };
            delBorrow(libraryResponse);
            clearForms();
            fetchData();
        }

        // button change status
        private void button4_Click(object sender, EventArgs e)
        {
            clearForms();
            fetchData();
        }

        private void fetchData()
        {
            var ds = _service.getLibraryData();
            dataGridViewLibraries.DataSource = ds;

            comboBoxId.DataSource = ds;
            comboBoxId.ValueMember = "id";
            comboBoxId.DisplayMember = "id";

            var data = _service.getLibraryDataExtra();

            comboBoxBook.DataSource = data;
            comboBoxBook.ValueMember = "idb";
            comboBoxBook.DisplayMember = "book";

            comboBoxClient.DataSource = data;
            comboBoxClient.ValueMember = "idc";
            comboBoxClient.DisplayMember = "client";
        }

        private void addBorrow(LibraryRequestJoin libraryRequestJoin)
        {
            _service.addBorrow(libraryRequestJoin);
        }

        private void modBorrow(LibraryModelJoin libraryModelJoin)
        {
            _service.modifyBorrow(libraryModelJoin);
        }

        private void delBorrow(LibraryResponse libraryResponse)
        {
            _service.deleteBorrow(libraryResponse);
        }

        private void clearForms()
        {
            comboBoxId.Items.Clear();
            comboBoxBook.Items.Clear();
            comboBoxClient.Items.Clear();
        }
    }
}
