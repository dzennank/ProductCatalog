using ProductsCatalog.Infrastructure.DTOs;
using ProductsCatalog.Models.Models;

namespace ProductsCatalog.PresentationGUI
{
    public partial class Form1 : Form
    {
        private readonly ProductService _productService;
        List<ProductDTO> products;
        public Form1()
        {
            InitializeComponent();
            _productService = new ProductService();

            button1.Click += Button1_Click;
            buttonFilter.Click += ButtonFilter_Click;
            buttonReset.Click += ButtonReset_Click;
            this.Load += new System.EventHandler(this.Form1_Load);
        }

        private async void ButtonReset_Click(object? sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = products;
            LoadButtons();
        }
        private async void ButtonFilter_Click(object? sender, EventArgs e)
        {
            string minValueText = numericUpDownMinPrice.Text;
            string maxValueText = numericUpDownMaxPrice.Text;

            string productNameText = textBoxSearch.Text;
            List<string> filters = new List<string>();
            if (!string.IsNullOrWhiteSpace(productNameText))
            {
                filters.Add($"productName={Uri.EscapeDataString(productNameText)}");
            }

            if (!string.IsNullOrWhiteSpace(minValueText))
            {
                filters.Add($"minPrice={minValueText}");
            }

           
            if (!string.IsNullOrWhiteSpace(maxValueText))
            {

                filters.Add($"maxPrice={maxValueText}");
            }
            
            string filter = string.Join("&", filters);
            var filteredProducts = await _productService.GetFilteredProductsAsync(filter);
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = filteredProducts;
            LoadButtons();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                products = await _productService.GetProductsAsync();
                dataGridView1.DataSource = products;
                LoadButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške: " + ex.Message);
            }
        }
        private async void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the Edit or Delete button columns
            if (e.RowIndex < 0) return; // Header row clicked

            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                // Handle Edit button click
                ProductDTO product = (ProductDTO)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                AddProduct editProduct = new AddProduct("EDIT", product);
                editProduct.ProductAdded += OnProductAdded;
                editProduct.ShowDialog();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                // Handle Delete button click
                var product = (ProductDTO)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                bool isDeleted = await _productService.DeleteProductAsync(product.Id);
                if (isDeleted)
                {
                    MessageBox.Show("Product is successfuly deleted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    products.Remove(product);
                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = products;
                    LoadButtons();

                }
            }
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ProductAdded += OnProductAdded;
            addProduct.ShowDialog();
        }
        private void OnProductAdded(ProductDTO newProduct, string action)
        {
            if (action != "EDIT")
            {
                products.Add(newProduct);
            }
            else
            {
                ProductDTO existingProduct = products.Find(p => p.Id == newProduct.Id);
                if (existingProduct != null)
                {
                    existingProduct.ProductName = newProduct.ProductName;
                    existingProduct.Price = newProduct.Price;
                    existingProduct.Description = newProduct.Description;
                    existingProduct.StockQuantity = newProduct.StockQuantity;
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = products;
            LoadButtons();
        }

        private void LoadButtons()
        {
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(editButtonColumn);

            // Add Delete button column
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(deleteButtonColumn);
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }
    }
}
