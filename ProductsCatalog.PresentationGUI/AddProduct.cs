using ProductsCatalog.Infrastructure.DTOs;
using ProductsCatalog.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductsCatalog.PresentationGUI
{
    public partial class AddProduct : Form
    {
        string Action = string.Empty;
        ProductDTO product = new ProductDTO();
        List<int> categories = new List<int>();
        private readonly ProductService _productService;
        public event Action<ProductDTO, string> ProductAdded;
        public AddProduct(string action = "CREATE", ProductDTO productArg = null)
        {
            InitializeComponent();
            Action = action;
            product = productArg;
            _productService = new ProductService();
            button2.Click += Button1_Click;
            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 999999;
            numericUpDown2.Minimum = 0;
            numericUpDown2.Maximum = 999999;
            GenerateCategoriesComboBoxItems();
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            if (Action == "EDIT")
            {
                button2.Text = "Update Product";
                richTextBox1.Text = product.ProductName;
                richTextBox2.Text = product.Description;

                numericUpDown1.Value = product.Price;
                numericUpDown2.Value = product.StockQuantity;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is Category selectedCategory)
            {
                int selectedCategoryId = selectedCategory.CategoryId;
                categories.Add(selectedCategoryId);                                        
            }
        }

        private async void Button1_Click(object? sender, EventArgs e)
        {
            if (Action != "EDIT")
            {
                CreateProductDto createProductDto = new CreateProductDto
                {
                    ProductName = richTextBox1.Text,
                    Description = richTextBox2.Text,
                    Price = numericUpDown1.Value,
                    StockQuantity = (int)numericUpDown2.Value,
                    CreatedAt = DateTime.Now,
                    CategoryIds = categories
                };

                bool IsProductAdded = await _productService.AddProductAsync(createProductDto);
                if (IsProductAdded)
                {
                    ProductDTO newProduct = new ProductDTO
                    {
                        ProductName = createProductDto.ProductName,
                        Description = createProductDto.Description,
                        Price = createProductDto.Price,
                        StockQuantity = createProductDto.StockQuantity,
                        CreatedAt = createProductDto.CreatedAt
                    };
                    ProductAdded?.Invoke(newProduct, "CREATE");
                    MessageBox.Show("Product is successfuly added", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            } else
            {
                UpdateProductDto updateProductDto = new UpdateProductDto
                {
                    ProductName = richTextBox1.Text,
                    Description = richTextBox2.Text,
                    Price = numericUpDown1.Value,
                    StockQuantity = (int)numericUpDown2.Value,
                    CategoryIds = categories
                };

                bool IsProductUpdated = await _productService.UpdateProductAsync(product.Id, updateProductDto);
                if (IsProductUpdated)
                {
                    ProductDTO newProduct = new ProductDTO
                    {
                        Id = product.Id,
                        ProductName = updateProductDto.ProductName,
                        Description = updateProductDto.Description,
                        Price = updateProductDto.Price,
                        StockQuantity = updateProductDto.StockQuantity,
                       
                    };
                    ProductAdded?.Invoke(newProduct, "EDIT");
                    MessageBox.Show("Product is successfuly updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
          
        }

        private void GenerateCategoriesComboBoxItems()
        {
            List<Category> categoriesCBI = new List<Category>();

            categoriesCBI.Add(new Category { CategoryId = 1, CategoryName = "Fitness Equipment" });
            categoriesCBI.Add(new Category { CategoryId = 2, CategoryName = "Gym Accessories" });
            categoriesCBI.Add(new Category { CategoryId = 3, CategoryName = "Sportswear" });
            comboBox1.Items.Clear();
            comboBox1.DataSource = categoriesCBI;
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryId";
            

        }
    }
}
