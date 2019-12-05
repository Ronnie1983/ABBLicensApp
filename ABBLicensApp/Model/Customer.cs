using System.Collections.Generic;

namespace ABBLicensApp.Model
{
    public class Customer
    {
        private string _companyName;
        private string _addresse;
        private string _email;
        private int _id;
        private List<string> _notes;
        private Product _products;
        private string _phoneNumber;
        private string _contactName;

        public void AddProduct()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveProduct()
        {
            throw new System.NotImplementedException();
        }

        public void AddComments()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteComments()
        {
            throw new System.NotImplementedException();
        }
    }
}