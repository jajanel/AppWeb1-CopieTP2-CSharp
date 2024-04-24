using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace TP2_H24_Code.Models
{
    public abstract class Catalogue
    {
        /// <summary>
        /// surcharge de methode dans les catalogues enfants. 
        /// </summary>
        public virtual void Ajouter() 
        {
        }
        /// <summary>
        /// surcharge de methode dans les catalogues enfants. 
        /// </summary>
        public virtual void Sauvegarder()
        {
         
        }

    }
}
