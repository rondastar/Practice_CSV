using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_CSV
{
    public class CoffeeMug 
    {
        string _handleType;
        string _color;
        string _material;

        public CoffeeMug() // Default Constructor
        {

        }
        public CoffeeMug(string handleType, string color, string material)
        {
            _handleType = handleType;
            _color = color;
            _material = material;
        }

        // public properties for each field that will load in the CSV
        public string HandleType { get => _handleType; set => _handleType = value; }
        public string Color { get => _color; set => _color = value; }
        public string Material { get => _material; set => _material = value; }

        //public int CompareTo(CoffeeMug other)
        //{
        //    // sorts by size
        //    if(this._sizeInOz > other.SizeInOz)
        //    {
        //        return 1;
        //    }
        //    else if(this._sizeInOz < other.SizeInOz)
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        public override string ToString()
        {
            return $"Handle: {HandleType} - Color: {Color} - Material: {Material}";
        }
    }
   
}
