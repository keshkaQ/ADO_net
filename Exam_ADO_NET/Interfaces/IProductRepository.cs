using Exam_ADO_NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_ADO_NET.Interfaces
{
    public interface IProductRepository
    {
        bool AddProduct(ProductModel productModel);
        bool DeleteProduct(int productId);
        bool UpdateProduct(ProductModel productModel);
        List<ProductModel> GetAllProducts();
        ProductModel GetProductById(int productId);
    }
}
