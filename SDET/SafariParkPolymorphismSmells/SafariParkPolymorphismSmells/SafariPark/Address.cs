using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesApp
{
    public class Address
    {
        public int HouseNo { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }

        public Address(int houseNo, string street, string town)
        {
            HouseNo = houseNo;
            Street = street;
            Town = town;
        }

        public string GetAddress()
        {
            return $"Address: {HouseNo} {Street}, {Town}";
        }
    }
}
