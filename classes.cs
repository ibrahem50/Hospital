using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hospitaal
{
    abstract class person
    {
        //data member 
        private string name;
        private string id;
        private string address;
        private string age;
        private string phonenumber;

        //defult constructour
        public person()
        {
            name = "";
            id = "";
            address = "";
            age = "";
            phonenumber = "";
        }
        //parametric constructour
        public person(string n, string i, string d, string a, string p)
        {
            name = n;
            id = i;
            address = d;
            age = a;
            phonenumber = p;
        }
        public void set_name(string n)
        {
            name = n;
        }
        public void set_id(string ad)
        {
            id = ad;

        }
        public string get_id()
        {
            return id;
        }
        public void set_address(string d)
        {
            address = d;
        }
        public void set_age(string a)
        {
            age = a;
        }
        public void set_phonenumber(string p)
        {
            phonenumber = p;
        }
        public string get_name()
        {
            return name;
        }
        public string get_address()
        {
            return address;
        }
        public string get_age()
        {
            return age;
        }
        public string get_phonenumber()
        {
            return phonenumber;
        }
        public abstract void DisplayInfo();
    }
    class doctor:person { 
               
          public bool IsHead;
        public string departmentname;
        public List<residentpatient> Repatients;
        public List<appointmentpatient> Appatients;
        public List<appointment> Appointments;
        public bool free;
        
        //Doctor Class Constructor
        public doctor()
        {
            
            IsHead = false;
            departmentname = "";
            Repatients =new List<residentpatient>();
            Appatients = new List<appointmentpatient>();
            Appointments = new List<appointment>();
            free = true;
        
        }
        public doctor(string x, string y, string z, string q, string g, bool l,List<residentpatient> p, List<appointmentpatient>aa, List<appointment> a ,string aq,bool e)
            : base(x, y, z, q, g)
        {
            departmentname = aq;
            IsHead = l;
            Repatients = p;
            Appatients = aa;
            Appointments = a;
            free = e;
        }
        public string getdepartment()
        {
            return departmentname;
        }
        //public void Is_Head(bool x)
        //{
        //    if (x == true)
        //        IsHead = true;
        //    else
        //        IsHead = false;
        //} 
        public void isfree(appointment b)
        {
     
            string x=b.date;
            double z=b.Duration;
            for (int i = 0; i < Appointments.Count; i++)
            {
                if ((x == Appointments[i].date && z >= Appointments[i].Duration && z < (Appointments[i].Duration + 0.30)) || (x == Appointments[i].date && (z + .30) > (Appointments[i].Duration) && (z + .30) < (Appointments[i].Duration) + .30))
                {
                    free = false;
                    break;
                }
                else
                {
                    free = true;
                    
                }
            }
        }
        
      public override void DisplayInfo()
        {
          
                    
        } 

        
       

        //function to add patients
        public void addresidentpatient(residentpatient patient)
        {
            Repatients.Add(patient);
        }
        public void addappointmentpatient(appointmentpatient a)
        {
       
            Appatients.Add(a);
        }
        //function to add appointmens
        public void addAppointment(appointment appointment)
        {
        
            this.Appointments.Add(appointment);
        }
     

    }
    class nurse:person {
        public string depart;
        public List<standardRoom> S_room;
        public List<PrivateRoom> l_PrivateRooms;
        public List<SemiPrivateRoom> l_SemiPrivateRoom;
        public List<residentpatient> l_patients;
        public nurse()
        {
            depart = "";
            S_room = new List<standardRoom>();
            l_patients = new List<residentpatient>();
            l_PrivateRooms = new List<PrivateRoom>();
            l_SemiPrivateRoom = new List<SemiPrivateRoom>();

        }
        public void addpatient(residentpatient p)
        {
            l_patients.Add(p);
        }

        public void set_nameofdepart(string dep)
        {
            depart = dep;
        }
        public void set_listofpatient(List<residentpatient> l_p)
        {
            l_patients = l_p;
        }

     
        public void addstandardroom(standardRoom r)
        {
            S_room.Add(r);
        }
        public void addsemiprivateroom(SemiPrivateRoom s)
        {
            l_SemiPrivateRoom.Add(s);
        }
        public void addprivateroom(PrivateRoom p)
        {
            l_PrivateRooms.Add(p);

        }



        public void set_listofsemiprivateroom(List<SemiPrivateRoom> s_p)
        {
            l_SemiPrivateRoom = s_p;
        }
       public void set_listofprivateroom(List<PrivateRoom> l_p)
        {
            l_PrivateRooms = l_p;
        }
       public void set_listofstandardroom(List<standardRoom> s)
       {
           S_room = s;
       }

        public void set_listofroom(List<SemiPrivateRoom> l_s)
        {
            l_SemiPrivateRoom = l_s;
        }
        public void deletepatient(residentpatient a)
        {
            l_patients.Remove(a);
        }
        public override void DisplayInfo()
        {

        }
    }
    class appointment {
     public   string date;
      public  double Duration;
      public  doctor Doctor;
      public  appointmentpatient Patient;
     // public bool free;
     public appointment()
      {
          date = "";
          Duration = 0.0;
          Doctor = new doctor();
          Patient = new appointmentpatient();
        //  free = false;
      }
     public appointment(string x, double y, doctor d, appointmentpatient p)
     {
         date = x;
         Duration = y;
         Doctor = d;
         Patient = p;
        // free = z;
     }
     

   /*  public bool checkFree(appointment x,string dat ,string durat)
     {
        double r= Convert.ToDouble(durat)+0.30;
        double z = Convert.ToDouble(x.Duration);
         if (z<r&z+0.30>r&x.date==dat)
             free = false;
         else
             free = true;

         return free;
     }*/
     public void adddoctor(doctor d)
     {
         Doctor = d;
     }
     public void addpatient(appointmentpatient p)
     {
         Patient = p;
     }
    
   }
    class room  {
        public  List<nurse> Nurses;
        public  List<residentpatient> Patients;
        public int nBeds;
        public int availableBeds;
        public int price;
        public bool full;
        public string Roomnumber;
      

        //Room Class Consructor
        public room()
        {
            Roomnumber = "";
            Patients = new List<residentpatient>();
            Nurses = new List<nurse>();
            nBeds =0;
            price = 0;
            full = false;
        }
        public void setlistofnurse(List<nurse> nu)
        {
            Nurses = nu;
        }
        //function to add Nurses in the room
        public void addNurse(nurse nurse)
        {
            
            this.Nurses.Add(nurse);
        }

        //function to check if the room is full
      /*  public bool IsFull()
        {
            return this.full;
        }*/


        //function to add patients in the room
        public void addPatient(residentpatient pa)
        {
            if(full==false)
            {
                Patients.Add(pa);
                availableBeds--;
                if(availableBeds<1)
                {
                    full = true;
                }
                
            }
        }
        public void deletepatient(residentpatient p)
        {
            Patients.Remove(p);
            availableBeds++;
            full = false;
        }
}
    class PrivateRoom :room
    {
        public PrivateRoom()
        {
            nBeds = 1;
            price = 300;
            availableBeds = 1;
        }
    }
    class SemiPrivateRoom : room
     {
         public SemiPrivateRoom()
         {
             //cjange the number of beds and the price per night for the room
             nBeds = 2;
             price = 200;
             availableBeds = 2;
         }

     }
    class standardRoom : room
     {
         public standardRoom()
         {
            
             nBeds = 4;
             price = 100;
             availableBeds = 4;
         }
     }
    class department
    {
        public List<doctor> doct;
        public List<patient> pat;
        public List<nurse> nu;
        public doctor head;
        public bool headdoctor;
       public string name;
        public department()
        {
            doct = new List<doctor>();
            pat = new List<patient>();
            head = new doctor();
            name = "";
            nu = new List<nurse>();
            headdoctor = false;
        }
        public department(List<doctor> d, List<patient> p, doctor a, string x)
        {
            doct = d;
            pat = p;
            head = a;
            name = x;

        }
        public void adddoctor(doctor x)
        {
            if(x.departmentname==name)
            doct.Add(x);
        }
      
        public void addpatient(patient p)
        {
            pat.Add(p);
        }
        public void sethead(doctor a)
        {
            head = a;
            a.IsHead = true;
            headdoctor = true;
        }
        public void addnurse(nurse a)
        {
            nu.Add(a);
        }

        

    }
    class patient: person
    {
        
        public doctor doc;
        public string bill;
        public string medicaldiagonis;
        public string deparname;


        //defult constructour
        public patient()
        {
           
            doc = new doctor();
            bill = "";
            medicaldiagonis = "";
            deparname = "";
        }


        //parametric constructour
        public patient(string na, string i, string ad, string ag, string ph, string b,string md,string z ,doctor d)
            : base(na, i, ad, ag, ph)
        {
          
            bill = b;
            deparname=z;
            doc = d;
            medicaldiagonis = md;
        }


        public void adddoctor(doctor d)
        {

            doc = d;

        }


       


        public override void DisplayInfo()
        {
                
        }


    }
    class residentpatient : patient
    {

        public string room;
        public List<nurse> nurs;
        public string medicinehistory;
        public residentpatient()
        {
            nurs = new List<nurse>();
            room ="";
            medicinehistory="";
        }

        public residentpatient(string n, string d, string ad, string ag, string ph,string b, string md,string de, doctor a, string mh, string r ,List<nurse>nar)
            : base(n,d,ad,ag,ph,b,md,de,a)
        {
            nurs = nar;
            medicinehistory = mh;
            room = r;

        }
        
        public void addnurse(nurse a)
        {
            nurs.Add(a);
        }

    }
    class appointmentpatient : patient
    {

        public appointment appointment;

        public appointmentpatient()
        {

            appointment = null;
        }
         public appointmentpatient(string na, string i, string ad, string ag, string ph, string b,string md,string z ,doctor d , appointment a)
            : base(na, i, ad, ag, ph,b,md,z,d){
                appointment = a;
    }
        
    }

}
    