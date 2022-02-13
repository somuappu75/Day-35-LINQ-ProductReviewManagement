﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LINQ_ProductReviewManagement
{
    class DataTableForProductManagement
    {

        DataTable table = new DataTable();
        public void AddDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("productId");
            table.Columns.Add("UserId");
            table.Columns.Add("Ratings");
            table.Columns.Add("Reviews");
            table.Columns.Add("isLike");
            table.Rows.Add("1", "1", "5", "Good", true);
            table.Rows.Add("2", "3", "4", "Good", true);
            table.Rows.Add("3", "4", "4", "Good", true);
            table.Rows.Add("4", "5", "5", "Good", true);
            table.Rows.Add("5", "4", "3", "Average", true);
            table.Rows.Add("6", "5", "1", "Bad", false);
            table.Rows.Add("7", "10", "5", "Good", true);
            table.Rows.Add("8", "10", "5", "Good", true);
            table.Rows.Add("9", "3", "4", "Good", true);
            table.Rows.Add("10", "2", "2", "Bad", false);
            table.Rows.Add("11", "3", "3", "Average", true);
            table.Rows.Add("12", "1", "3", "Average", false);
        }
        //uc-9 retrieving data
        public void CallForRetrievingData()
        {
            //CALLING  retrieving records method from product management
            ProductManagement productManagement = new ProductManagement();
            productManagement.RetrievingRecords(table);
        }
    }
}
