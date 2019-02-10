using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerology.Model
{
   public class Customer
    {
       private Guid _id;
       private string _LastName;
       private string _FirstName;
       private string _SecondName;
       private DateTime _BirthDate;
       private DateTime _CalculateDate;


       public Customer()
       {
           _id = Guid.NewGuid();
        }

       public Guid ID
       {
           get { return _id; }
       }

      /// <summary>
      /// Фамилия
      /// </summary>
       public string LastName
       {
           get
           {
               return _LastName;
           }
           set
           {
               _LastName = value;
               OnPropertyChanged("LastName");
           }
       }

       /// <summary>
       /// Имя
       /// </summary>
       public string FirstName
       {
           get
           {
               return _FirstName;
           }
           set
           {
               _FirstName = value;
               OnPropertyChanged("FirstName");
           }
       }
 
       /// <summary>
       /// Отчество
       /// </summary>
       public string SecondName
       {
           get
           {
               return _SecondName;
           }
           set
           {
               _SecondName = value;
               OnPropertyChanged("SecondName");
           }
       }

       /// <summary>
       /// Дата рождения
       /// </summary>
       public DateTime BirthDate
       {
           get
           {
               return _BirthDate;
           }
           set
           {
               _BirthDate = value;
               OnPropertyChanged("BirthDate");
           }
       }

       public string MobilePhone { get; set; }
       public string WorkPhone { get; set; }
       public string HomePhone { get; set; }
       public string Email { get; set; }
 


       /// <summary>
       /// Дата составления нумерологической карты
       /// </summary>
       public DateTime CalculateDate
       {
           get
           {
               return _CalculateDate;
           }
           set
           {
               _CalculateDate = value;
               OnPropertyChanged("CalculateDate");
           }
       }


       public event PropertyChangedEventHandler PropertyChanged;
       private void OnPropertyChanged(string propertyName)
       {
           if (PropertyChanged != null)
           {
               PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
           }
       }
 
    }
}
