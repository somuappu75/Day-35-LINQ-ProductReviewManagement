using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LINQ_ProductReviewManagement
{
    class ProductManagement
    {
        //uc2-1
        public readonly DataTable dataTable = new DataTable();

        public void TopRecords(List<ProductReview> listReview)
        {
            //using query syntax
            var recordedData = (from productReviews in listReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            //using lambda syntax
            var recordData = listReview.OrderByDescending(r => r.Rating).Take(3);
            foreach (var list in recordData)
            {
                Console.WriteLine("ProductId:-" + list.ProductId + " UserId:-" + list.UserId + " Ratings:-" + list.Rating + " Review:-" + list.Review + " IsLike:-" + list.isLike);
            }
        }

       //Uc-3 Selected records with where condition
        public void SelectedRecords(List<ProductReview> listReview)
        {
            //lambda syntax
            var recordData = listReview.Where(r => r.Rating > 3 && (r.ProductId == 1 || r.ProductId == 4 || r.ProductId == 9)).ToList();
            //query syntax
            var recordedData = (from productReviews in listReview
                                where productReviews.Rating > 3 && (productReviews.ProductId == 1 || productReviews.ProductId == 4 || productReviews.ProductId == 9)
                                select productReviews);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:-" + list.ProductId + " UserId:-" + list.UserId + " Ratings:-" + list.Rating + " Review:-" + list.Review + " IsLike:-" + list.isLike);
            }
        }
        //UC-4 grouping by user id 
        public void countOfReviews(List<ProductReview> listProductReview)
        {
            //lambda syntax
            var recordData = listProductReview.GroupBy(r => r.UserId).Select(r => new { productId = r.Key, count = r.Count() });
            //query syntax
            var recordedData = from products in listProductReview
                               group products by products.UserId into g
                               select new
                               {
                                   userId = g.Key,
                                   count = g.Count()
                               };

            foreach (var list in recordedData)
            {
                Console.WriteLine("UserId:-" + list.userId + " Count:-" + list.count);
            }
        }
        //UC-5 Retrieves the product id and review 
        public void retrieveProductIDandreview(List<ProductReview> productReviewList)
        {
            var recordData = productReviewList.Select(r => new { r.ProductId, r.Review });
            foreach (var list in recordData)
            {
                Console.WriteLine("product Id:-" + list.ProductId + " Review :-" + list.Review);
            }
        }
        //UC-6 --skipping the top 5 records
        public void SkippingRecords(List<ProductReview> productReviewList)
        {
            var recordData = productReviewList.Skip(5);
            var recordedData = (from products in productReviewList
                                select products).Skip(5);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:-" + list.ProductId + " UserId:-" + list.UserId + " Ratings:-" + list.Rating + " Review:-" + list.Review + " IsLike:-" + list.isLike);
            }

        }
    }
}
