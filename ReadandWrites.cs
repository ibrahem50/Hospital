using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Hospitaal
{
    class ReadandWrites
    {

        //write list of nurse in file
        public void write_nurse(List<nurse> l_n)
        {
            FileStream fd = new FileStream("nurse_file.txt", FileMode.Truncate);
            fd.Close();
            FileStream fs = new FileStream("nurse_file.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < l_n.Count; i++)
            {

                string s;
                s = l_n[i].get_name() + "@" + l_n[i].get_id() + "@" + l_n[i].get_age() +"@"+ l_n[i].get_address() + "@" + l_n[i].get_phonenumber() + "@" + l_n[i].depart;
                sw.WriteLine(s);
                s = "";
                
                for (int q = 0; q < l_n[i].S_room.Count; q++)
                {
                    s += l_n[i].S_room[q].Roomnumber ;
                    if (q != l_n[i].S_room.Count - 1)
                        s += "@";
                }
                sw.WriteLine(s);
                s = "";
                for (int q = 0; q < l_n[i].l_SemiPrivateRoom.Count; q++)
                {
                    s += l_n[i].l_SemiPrivateRoom[q].Roomnumber;
                    if (q != l_n[i].l_SemiPrivateRoom.Count - 1)
                        s += "@";
                }
                sw.WriteLine(s);
                s = "";
                for (int q = 0; q < l_n[i].l_PrivateRooms.Count; q++)
                {
                    s += l_n[i].l_PrivateRooms[q].Roomnumber ;
                    if (q != l_n[i].l_PrivateRooms.Count - 1)
                        s += "@";
                }
                sw.WriteLine(s);
                s = "";

                for (int j = 0; j < l_n[i].l_patients.Count; j++)
                {
                    s += l_n[i].l_patients[j].get_id() ;
                    if (j != l_n[i].l_patients.Count - 1)
                        s += "@";
                }

                sw.WriteLine(s);
            }
            sw.Close();
        }

        //Read Nurse from file
        public void read_nurse(ref List<nurse> l_n)
        {
            if (File.Exists("nurse_file.txt"))
            {
                FileStream fs = new FileStream("nurse_file.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                while (sr.Peek() != -1)
                {

                    string str = sr.ReadLine();
                    string[] fields;
                    nurse n = new nurse();
                    fields = str.Split('@');
                    n.set_name(fields[0]);
                    n.set_id(fields[1]);
                    n.set_age(fields[2]);
                    n.set_address(fields[3]);
                    n.set_phonenumber(fields[4]);
                    n.set_nameofdepart(fields[5]);
                    str = "";
                    str = sr.ReadLine();
                    if (str != "")
                        fields = str.Split('@');
                    else
                        fields = new string[0];

                    List<residentpatient> l = new List<residentpatient>();
                    List<SemiPrivateRoom> serooms = new List<SemiPrivateRoom>();
                    List<standardRoom> strooms = new List<standardRoom>();
                    List<PrivateRoom> prirooms = new List<PrivateRoom>();
                    for (int y = 0; y < fields.Length; y++)
                    {

                        standardRoom x = new standardRoom();
                        x.Roomnumber = fields[y];
                        strooms.Add(x);


                    }
                    n.set_listofstandardroom(strooms);
                    str = "";
                    str = sr.ReadLine();
                    if (str != "")
                        fields = str.Split('@');
                    else
                        fields = new string[0];

                    for (int y = 0; y < fields.Length; y++)
                    {

                        SemiPrivateRoom x = new SemiPrivateRoom();
                        x.Roomnumber = fields[y];
                        serooms.Add(x);


                    }

                    n.set_listofsemiprivateroom(serooms);
                    str = "";
                    str = sr.ReadLine();
                    if (str != "")
                        fields = str.Split('@');
                    else
                        fields = new string[0];
                    for (int y = 0; y < fields.Length; y++)
                    {

                        PrivateRoom x = new PrivateRoom();
                        x.Roomnumber = fields[y];
                        prirooms.Add(x);


                    }
                    n.set_listofprivateroom(prirooms);
                    str = "";
                    str = sr.ReadLine();
                    if (str != "")
                        fields = str.Split('@');
                    else
                        fields = new string[0];
                    for (int i = 0; i < fields.Length; i++)
                    {
                        residentpatient p = new residentpatient();
                        p.set_id(fields[i]);
                        l.Add(p);
                    }
                    n.l_patients = l;
                    l_n.Add(n);
                }
                sr.Close();
            }
        }
        //write doctor in file
        public void Writing_Doctors_In_File(List<doctor> docs)
        {
            FileStream Fd = new FileStream("DoctorFile.txt", FileMode.Truncate);
            Fd.Close();
            FileStream FS = new FileStream("DoctorFile.txt", FileMode.Append);
            StreamWriter SW = new StreamWriter(FS);

            for (int i = 0; i < docs.Count(); i++)
            {
                string writing = docs[i].get_name() + "@" + docs[i].get_id() + "@"
                    + docs[i].get_age() + "@" + docs[i].get_address() + "@" + docs[i].get_phonenumber() + "@" + docs[i].departmentname
                    + "@" + docs[i].IsHead.ToString() +"@"+docs[i].free.ToString();
                SW.WriteLine(writing);
                writing = "";
                for (int j = 0; j < docs[i].Repatients.Count; j++)
                {
                    writing  += docs[i].Repatients[j].get_id() ;
                    if (j != docs[i].Repatients.Count - 1)
                        writing += "@";
                }
                SW.WriteLine(writing);
                writing = "";
                
                for (int j = 0; j < docs[i].Appatients.Count; j++)
                {
                    writing += docs[i].Appatients[j].get_id();
                    if (j != docs[i].Appatients.Count - 1)
                        writing += "@";
                }
                SW.WriteLine(writing);
                writing = "";
                for (int j = 0; j < docs[i].Appointments.Count; j++)
                {
                    writing += docs[i].Appointments[j].date + "@" + docs[i].Appointments[j].Duration;
                      if(docs[i].Appointments[j].Patient!=null)
                        writing += "@" + docs[i].Appointments[j].Patient.get_id();
                       if (j != docs[i].Appointments.Count - 1)
                       writing += "@";

                }
                SW.WriteLine(writing);
            }

            SW.Close();
        }

        //Read doctor from file
        public void Read_doctor(ref List<doctor> l_d)
        {
            if (File.Exists("DoctorFile.txt"))
            {

                FileStream fs = new FileStream("DoctorFile.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (sr.Peek() != -1)
                {
                    string str = sr.ReadLine();
                    string[] fields;
                    doctor d = new doctor();
                    fields = str.Split('@');
                    d.set_name(fields[0]);
                    d.set_id(fields[1]);
                    d.set_age(fields[2]);
                    d.set_address(fields[3]);
                    d.set_phonenumber(fields[4]);
                    d.departmentname = (fields[5]);
                    if (fields[6] == "True")
                    {
                        d.IsHead = (true);
                    }
                    else
                        d.IsHead = (false);
                    if (fields[7] == "True")
                    {
                        d.free = (true);
                    }
                    else
                        d.free = (false);
                    str = "";
                    str = sr.ReadLine();
                    if (str != "")
                        fields = str.Split('@');
                    else
                        fields = new string[0];

                    List<residentpatient> l = new List<residentpatient>();
                    List<appointmentpatient> A = new List<appointmentpatient>();
                    List<appointment> ap = new List<appointment>();
                    for (int i = 0; i < fields.Length; i++)
                    {
                        residentpatient p = new residentpatient();
                        p.set_id(fields[i]);
                        l.Add(p);
                    }
                    d.Repatients= l;
                    str = "";
                    str = sr.ReadLine();
                    if (str != "")
                    fields = str.Split('@');
                    else
                        fields = new string[0];
                    for (int i = 0; i < fields.Length; i++)
                    {
                        appointmentpatient p = new appointmentpatient();
                        p.set_id(fields[i]);
                        A.Add(p);
                        
                    }
                    d.Appatients = A;
                    str = "";
                    str = sr.ReadLine();
                    if (str != "")
                        fields = str.Split('@');
                    else
                        fields = new string[0];
                    for (int i = 0; i < fields.Length; i++)
                    {
                        appointment a = new appointment();
                        a.date = (fields[i]);
                        string x = (fields[i + 1]);
                        a.Duration = Convert.ToDouble((x));
                        a.Patient.set_id(fields[i + 2]);
                        ap.Add(a);
                        i += 2;

                    }
                    d.Appointments = ap;
                        l_d.Add(d);
                }
                sr.Close();
            }
        }
        //write patient file
        public void Writing_patients_In_File(List<patient> patients)
        {
            FileStream fd = new FileStream("patientFile.txt", FileMode.Truncate);
            fd.Close();
            FileStream FS = new FileStream("patientFile.txt", FileMode.Append);
            StreamWriter SW = new StreamWriter(FS);

            for (int i = 0; i < patients.Count(); i++)
            {
                string writing = patients[i].get_name() + "@" + patients[i].get_id() + "@"
                    + patients[i].get_age() + "@" + patients[i].get_address() + "@" + patients[i].get_phonenumber() + "@" +  patients[i].medicaldiagonis+"@"+patients[i].bill;

                SW.WriteLine(writing);

            }

            SW.Close();
        }
        //Read patient from file
        public void read_patients(ref List<patient> patients)
        {
            if (File.Exists("patientFile.txt"))
            {
                FileStream fs = new FileStream("patientFile.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (sr.Peek() != -1)
                {
                    string str = sr.ReadLine();
                    string[] fields;
                    patient p = new appointmentpatient();
                    fields = str.Split('@');
                    p.set_name(fields[0]);
                    p.set_id(fields[1]);
                    p.set_age(fields[2]);
                    p.set_address(fields[3]);
                    p.set_phonenumber(fields[4]);
                    p.medicaldiagonis = (fields[5]);
                    p.bill = (fields[6]);

                    patients.Add(p);
                }
                sr.Close();
            }
        }

        //write in file list of appointment patient 
        public void Writing_apppinmentpatients_In_File(List<appointmentpatient> appo_patients)
        {
            FileStream Fd = new FileStream("appointmentpatientFile.txt", FileMode.Truncate);
            Fd.Close();
            FileStream FS = new FileStream("appointmentpatientFile.txt", FileMode.Append);
            StreamWriter SW = new StreamWriter(FS);

            for (int i = 0; i < appo_patients.Count(); i++)
            {
                string writing = appo_patients[i].deparname + "@" +appo_patients[i].get_name() + "@" + appo_patients[i].get_id() + "@"
                    + appo_patients[i].get_age() + "@" + appo_patients[i].get_address() + "@" + appo_patients[i].get_phonenumber() +
                     "@"+ appo_patients[i].appointment.date + "@" + appo_patients[i].appointment.Duration + "@" + appo_patients[i].medicaldiagonis + "@"+appo_patients[i].bill+"@"+appo_patients[i].doc.get_id();

                SW.WriteLine(writing);

            }

            SW.Close();
        }

        //Read appointment patient from file
        public void read_apppinmentpatients(ref List<appointmentpatient> appo_patients)
        {
            if (File.Exists("appointmentpatientFile.txt"))
            {
                FileStream fs = new FileStream("appointmentpatientFile.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (sr.Peek() != -1)
                {
                    string str = sr.ReadLine();
                    string[] fields;
                    appointmentpatient p = new appointmentpatient();
                    appointment a = new appointment();
                    fields = str.Split('@');
                    p.deparname=(fields[0]);
                    p.set_name(fields[1]);
                    p.set_id(fields[2]);
                    p.set_age(fields[3]);
                    p.set_address(fields[4]);
                    p.set_phonenumber(fields[5]);
                    a.date = (fields[6]);
                    string x = (fields[7]);
                    a.Duration =Convert.ToDouble((x));
                    p.appointment = a;
                   /* p.appointment.date = (fields[6]);
                    p.appointment.Duration = Convert.ToDouble((fields[7]));*/
                    p.medicaldiagonis = (fields[8]);
                    p.bill = (fields[9]);
                    p.doc.set_id(fields[10]);
                    appo_patients.Add(p);
                }
                sr.Close();
            }
        }

        //write in file list of resident patient
        public void Writing_residentpatient_In_File(List<residentpatient> res_patients)
        {
            FileStream Fd = new FileStream("residentpatientfile.txt", FileMode.Truncate);
            Fd.Close();
            FileStream FS = new FileStream("residentpatientfile.txt", FileMode.Append);
            StreamWriter SW = new StreamWriter(FS);

            for (int i = 0; i < res_patients.Count(); i++)
            {
                string writing =res_patients[i].deparname+"@"+ res_patients[i].get_name() + "@" + res_patients[i].get_id() + "@"
                    + res_patients[i].get_age() + "@" + res_patients[i].get_address() + "@" + res_patients[i].get_phonenumber() +
                    "@" + res_patients[i].room + "@" + res_patients[i].medicaldiagonis +"@"+res_patients[i].bill +"@"+res_patients[i].medicinehistory+"@"+res_patients[i].doc.get_id();
              
                SW.WriteLine(writing);
                writing = "";
                for (int j = 0; j < res_patients[i].nurs.Count; j++)
                {
                    writing += res_patients[i].nurs[j].get_id();
                    if (j != res_patients[i].nurs.Count - 1)
                        writing += "@";
                }
                SW.WriteLine(writing);
            }

            SW.Close();
        }

        //read resident patient from file
        public void read_residentpatient(ref List<residentpatient> res_patients)
        {
            if (File.Exists("residentpatientfile.txt"))
            {
                FileStream fs = new FileStream("residentpatientfile.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (sr.Peek() != -1)
                {
                    string str = sr.ReadLine();
                    string[] fields;
                    residentpatient p = new residentpatient();
                    fields = str.Split('@');
                    p.deparname = (fields[0]);
                    p.set_name(fields[1]);
                    p.set_id(fields[2]);
                    p.set_age(fields[3]);
                    p.set_address(fields[4]);
                    p.set_phonenumber(fields[5]);
                    p.room = (fields[6]);
                    p.medicaldiagonis = (fields[7]);
                    p.bill = (fields[8]);
                    p.medicinehistory = (fields[9]);
                    p.doc.set_id(fields[10]);
                    str = "";
                    str = sr.ReadLine();
                    if (str != "")
                        fields = str.Split('@');
                    else
                        fields = new string[0];

                    List<nurse> na = new List<nurse>();
                    for (int y = 0; y < fields.Length; y++)
                    {

                        nurse x = new nurse();
                        x.set_id(fields[y]);
                        na.Add(x);


                    }
                    p.nurs = na;
                    res_patients.Add(p);

                }
                sr.Close();
            }
        }

        //write in file list of rooms
        public void Writing_romm_In_File(List<room> rooms)
        {
            FileStream Fd = new FileStream("roomfile.txt", FileMode.Truncate);
            Fd.Close();
            FileStream FS = new FileStream("roomfile.txt", FileMode.Append);
            StreamWriter SW = new StreamWriter(FS);

            for (int i = 0; i < rooms.Count; i++)
            {
                string writing = rooms[i].Roomnumber+"@"+rooms[i].nBeds + "@" + rooms[i].availableBeds + "@" + rooms[i].price + "@" + rooms[i].full.ToString();

                for (int j = 0; j < rooms[i].Patients.Count; j++)
                {
                    writing += "@" + rooms[i].Patients[j].get_id();
                }
                for (int j = 0; j < rooms[i].Nurses.Count; j++)
                {
                    writing += "@" + rooms[i].Nurses[j].get_id();
                }
                SW.WriteLine(writing);
            }

            SW.Close();
        }

        //read rooms from file
        public void read_rooms(ref List<room> rooms)
        {
            if (File.Exists("roomfile.txt"))
            {
                FileStream fs = new FileStream("roomfile.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (sr.Peek() != -1)
                {
                    string str = sr.ReadLine();
                    string[] fields;
                    room r = new room();
                    fields = str.Split('@');
                    r.Roomnumber = fields[0];
                    r.nBeds = Convert.ToInt32(fields[1]);
                    r.availableBeds = Convert.ToInt32(fields[2]);
                    r.price = Convert.ToInt32(fields[3]);
                    if (fields[4] == "true")
                    {
                        r.full = (true);
                    }
                    else
                        r.full = (false);
                    for (int j = 5; j < (5 + r.nBeds - r.availableBeds); j++)
                    {
                        residentpatient p = new residentpatient();
                        p.set_id(fields[j]);
                        r.Patients.Add(p);
                    }
                    for (int j = (6+ r.nBeds - r.availableBeds); j < fields.Length; j++)
                    {
                        nurse n = new nurse();
                        n.set_id(fields[j]);
                        r.Nurses.Add(n);
                    }
                    rooms.Add(r);
                }
                sr.Close();
            }
        }
        //write in file list of standard rooms
        public void Writing_standardromm_In_File(List<standardRoom> sp_rooms)
        {

            FileStream Fd = new FileStream("standardroomfile.txt", FileMode.Truncate);
            Fd.Close();
            FileStream FS = new FileStream("standardroomfile.txt", FileMode.Append);
            StreamWriter SW = new StreamWriter(FS);

            for (int i = 0; i < sp_rooms.Count(); i++)
            {
                string writing = sp_rooms[i].Roomnumber + "@" + sp_rooms[i].nBeds + "@" + sp_rooms[i].availableBeds + "@" + sp_rooms[i].price + "@" + sp_rooms[i].full.ToString();
                SW.WriteLine(writing);
                writing = "";
                for (int j = 0; j < sp_rooms[i].Patients.Count; j++)
                {
                    writing += sp_rooms[i].Patients[j].get_id() ;
                    if (j != sp_rooms[i].Patients.Count - 1)
                        writing += "@";
                }
                SW.WriteLine(writing);
                writing = "";
               
                for (int j = 0; j < sp_rooms[i].Nurses.Count; j++)
                {
                    writing += sp_rooms[i].Nurses[j].get_id();
                    if (j != sp_rooms[i].Nurses.Count - 1)
                        writing += "@";
                }
                
                SW.WriteLine(writing);
            }

            SW.Close();
        }
        //read standard rooms from file
        public void read_standardrooms(ref List<standardRoom> st_rooms)
        {
            if (File.Exists("standardroomfile.txt"))
            {
                FileStream fs = new FileStream("standardroomfile.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (sr.Peek() != -1)
                {
                    string str = sr.ReadLine();
                    string[] fields;
                    standardRoom r = new standardRoom();

                    fields = str.Split('@');
                    r.Roomnumber = fields[0];
                    r.nBeds = Convert.ToInt32(fields[1]);
                    r.availableBeds = Convert.ToInt32(fields[2]);
                    r.price = Convert.ToInt32(fields[3]);
                    if (fields[4] == "true")
                    {
                        r.full = (true);

                    }
                    else
                        r.full = (false);
                        str = "";
                        str = sr.ReadLine();
                        if (str != "")
                            fields = str.Split('@');
                        else
                            fields = new string[0];
                        for (int j = 0; j < fields.Length; j++)
                        {
                            residentpatient p = new residentpatient();
                            p.set_id(fields[j]);
                            r.addPatient(p);
                        }

                        
                    str = "";
                    str = sr.ReadLine();
                    if (str != "")
                        fields = str.Split('@');
                    else
                        fields = new string[0];
                        for (int j = 0; j < fields.Length; j++)
                        {

                            nurse n = new nurse();
                            n.set_id(fields[j]);
                            r.Nurses.Add(n);
                        }
                    st_rooms.Add(r);
                }
                sr.Close();
            }
        }
        //write in file list of Private rooms
        public void Writing_privateromm_In_File(List<PrivateRoom> p_rooms)
        {

            FileStream Fd = new FileStream("privateroomfile.txt", FileMode.Truncate);
            Fd.Close();
            FileStream FS = new FileStream("privateroomfile.txt", FileMode.Append);
            StreamWriter SW = new StreamWriter(FS);

            for (int i = 0; i < p_rooms.Count; i++)
            {
                string writing = p_rooms[i].Roomnumber+"@"+p_rooms[i].nBeds + "@" + p_rooms[i].availableBeds + "@" + p_rooms[i].price + "@" + p_rooms[i].full.ToString();
                SW.WriteLine(writing);
                writing = "";
                for (int j = 0; j < p_rooms[i].Patients.Count; j++)
                {
                    writing += p_rooms[i].Patients[j].get_id();
                    if (j != p_rooms[i].Patients.Count - 1)
                        writing += "@";
                }
                SW.WriteLine(writing);
                writing = "";
                for (int j = 0; j < p_rooms[i].Nurses.Count; j++)
                {
                    writing +=  p_rooms[i].Nurses[j].get_id();
                    if (j != p_rooms[i].Nurses.Count - 1)
                        writing += "@";
                }
                SW.WriteLine(writing);
            }

            SW.Close();
        }

        //read Private rooms from file
        public void read_privaterooms(ref List<PrivateRoom> p_rooms)
        {
            if (File.Exists("privateroomfile.txt"))
            {
                FileStream fs = new FileStream("privateroomfile.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (sr.Peek() != -1)
                {
                    string str = sr.ReadLine();
                    string[] fields;
                    PrivateRoom r = new PrivateRoom();
                    fields = str.Split('@');
                    r.Roomnumber = fields[0];
                    r.nBeds = Convert.ToInt32(fields[1]);
                    r.availableBeds = Convert.ToInt32(fields[2]);
                    r.price = Convert.ToInt32(fields[3]);
                    if (fields[4] == "true")
                    {
                        r.full = (true);
                    }
                    else
                        r.full = (false);
                    str = "";
                    str = sr.ReadLine();
                    if (str != "")
                        fields = str.Split('@');
                    else
                        fields = new string[0];
                    for (int j = 0; j < fields.Length; j++)
                    {
                        residentpatient p = new residentpatient();
                        p.set_id(fields[j]);
                        r.addPatient(p);
                    }


                    str = "";
                    str = sr.ReadLine();
                    if (str != "")
                        fields = str.Split('@');
                    else
                        fields = new string[0];
                    for (int j = 0; j < fields.Length; j++)
                    {

                        nurse n = new nurse();
                        n.set_id(fields[j]);
                        r.Nurses.Add(n);
                    }
                    p_rooms.Add(r);
                }
                sr.Close();
            }
        }

        //write in file list of Semiprivate rooms
        public void Writing_semiprivateromm_In_File(List<SemiPrivateRoom> sp_rooms)
        {

            FileStream Fd = new FileStream("semiprivateroomfile.txt", FileMode.Truncate);
            Fd.Close();
            FileStream FS = new FileStream("semiprivateroomfile.txt", FileMode.Append);
            StreamWriter SW = new StreamWriter(FS);

            for (int i = 0; i < sp_rooms.Count(); i++)
            {
                string writing = sp_rooms[i].Roomnumber+"@"+sp_rooms[i].nBeds + "@" + sp_rooms[i].availableBeds + "@" + sp_rooms[i].price + "@" + sp_rooms[i].full.ToString();

                SW.WriteLine(writing);
                writing = "";
                for (int j = 0; j < sp_rooms[i].Patients.Count; j++)
                {
                    writing += sp_rooms[i].Patients[j].get_id();
                    if (j != sp_rooms[i].Patients.Count - 1)
                        writing += "@";
                }
                SW.WriteLine(writing);
                writing = "";

                for (int j = 0; j < sp_rooms[i].Nurses.Count; j++)
                {
                    writing += sp_rooms[i].Nurses[j].get_id();
                    if (j != sp_rooms[i].Nurses.Count - 1)
                        writing += "@";
                }

                SW.WriteLine(writing);
            }

            SW.Close();
        }

        //fill list of Semiprivate rooms from file
        public void read_semiprvateroomfile(ref List<SemiPrivateRoom> sp_rooms)
        {
            if (File.Exists("semiprivateroomfile.txt"))
            {
                FileStream fs = new FileStream("semiprivateroomfile.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (sr.Peek() != -1)
                {
                    string str = sr.ReadLine();
                    string[] fields;
                    SemiPrivateRoom r = new SemiPrivateRoom();
                    fields = str.Split('@');
                    r.Roomnumber = fields[0];
                    r.nBeds = Convert.ToInt32(fields[1]);
                    r.availableBeds = Convert.ToInt32(fields[2]);
                    r.price = Convert.ToInt32(fields[3]);
                    if (fields[4] == "true")
                    {
                        r.full = (true);
                    }
                    else
                        r.full = (false);
                    str = "";
                    str = sr.ReadLine();
                    if (str != "")
                        fields = str.Split('@');
                    else
                        fields = new string[0];
                    for (int j = 0; j < fields.Length; j++)
                    {
                        residentpatient p = new residentpatient();
                        p.set_id(fields[j]);
                        r.addPatient(p);
                    }


                    str = "";
                    str = sr.ReadLine();
                    if (str != "")
                        fields = str.Split('@');
                    else
                        fields = new string[0];
                    for (int j = 0; j < fields.Length; j++)
                    {

                        nurse n = new nurse();
                        n.set_id(fields[j]);
                        r.Nurses.Add(n);
                    }
                    sp_rooms.Add(r);
                }
                sr.Close();
            }
        }
        //write in file list of appointments
        public void Writing_appointments_In_File(List<appointment> app)
        {

            FileStream Fd = new FileStream("appointments.txt", FileMode.Truncate);
            Fd.Close();
            FileStream FS = new FileStream("appointments.txt", FileMode.Append);
            StreamWriter SW = new StreamWriter(FS);

            for (int i = 0; i < app.Count(); i++)
            {
                string writing = app[i].date + "@" + app[i].Duration + "@" + app[i].Doctor.get_id() + "@" + app[i].Patient.get_id() ;

                SW.WriteLine(writing);
            }

            SW.Close();
        }

        //read appointments from file
        public void read_appointments(ref List<appointment> app)
        {
            if (File.Exists("appointments.txt"))
            {
                FileStream fs = new FileStream("appointments.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (sr.Peek() != -1)
                {
                    string str = sr.ReadLine();
                    string[] fields;
                    appointment a = new appointment();
                    fields = str.Split('@');
                    a.date = (fields[0]);
                    a.Duration = Convert.ToDouble(fields[1]);
                    a.Doctor.set_id(fields[2]);
                    a.Patient.set_id(fields[3]);

                    app.Add(a);
                }
                sr.Close();
            }
        }

        //write in file list of department
        public void Writing_departments_In_File(List<department> dep)
        {

            FileStream Fd = new FileStream("department.txt", FileMode.Truncate);
            Fd.Close();
            FileStream FS = new FileStream("department.txt", FileMode.Append);
            StreamWriter SW = new StreamWriter(FS);

            for (int i = 0; i < dep.Count(); i++)
            {
                string writing = dep[i].name + "@" + dep[i].headdoctor.ToString()+"@"+ dep[i].head.get_id() ;

                SW.WriteLine(writing);
            }


            SW.Close();
        }

        //read department from file
        public void read_departments(ref List<department> dep)
        {
            if (File.Exists("department.txt"))
            {
                FileStream fs = new FileStream("department.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (sr.Peek() != -1)
                {
                    string str = sr.ReadLine();
                    string[] fields;
                    department d = new department();
                    fields = str.Split('@');
                    d.name = fields[0];
                    d.headdoctor = Convert.ToBoolean((fields[1]));
                    d.head.set_id(fields[2]);
                    dep.Add(d);
                }
                sr.Close();
            }
        }


    }

}