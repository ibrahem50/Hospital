using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospitaal
{
    public partial class Form1 : Form
    {
        static List<residentpatient> Rpatients = new List<residentpatient>();
        static List<appointmentpatient> Apatients = new List<appointmentpatient>();
        static List<doctor> doctors = new List<doctor>();
        static List<nurse> nurses = new List<nurse>();
        static List<patient> patient = new List<patient>();
        static List<department> departments = new List<department>();
        static List<appointment> appointments = new List<appointment>();
        static List<room> rooms = new List<room>();
        static List<SemiPrivateRoom> Srooms = new List<SemiPrivateRoom>();
        static List<standardRoom> STrooms = new List<standardRoom>();
        static List<PrivateRoom> Prooms = new List<PrivateRoom>();
        static int D_ID = 1;
        static int RP_ID = 50;
        static int AP_ID = 100;
        static int N_ID = 150;
        static int standard_Room_number = 1;
        static int semiprivate_Room_number = 100;
        static int private_room_number = 200;
        public Form1()
        {
            InitializeComponent();
            Hospitaal.ReadandWrites h = new ReadandWrites();
            h.read_residentpatient(ref Rpatients);
            h.read_apppinmentpatients(ref Apatients);
            h.Read_doctor(ref doctors);
            h.read_nurse(ref nurses);
            h.read_rooms(ref rooms);
            h.read_departments(ref departments);
            h.read_appointments(ref appointments);
            h.read_semiprvateroomfile(ref Srooms);
            h.read_privaterooms(ref Prooms);
            h.read_standardrooms(ref STrooms);
            h.read_patients(ref patient);
            if (doctors.Count > 0)
                D_ID = Convert.ToInt32(doctors[doctors.Count - 1].get_id()) + 1;
            else
                D_ID = 1;
            if (nurses.Count > 0)
                N_ID = Convert.ToInt32(nurses[nurses.Count - 1].get_id()) + 1;
            else
                N_ID = 150;
            if (Rpatients.Count > 0)
                RP_ID = Convert.ToInt32(Rpatients[Rpatients.Count - 1].get_id()) + 1;
            else
                RP_ID = 50;
            AP_ID = 100 + Apatients.Count;
            standard_Room_number = 1 + STrooms.Count;
            semiprivate_Room_number = 100 + Srooms.Count;
            private_room_number = 200 + Prooms.Count;


        }



        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hospitaal.ReadandWrites h = new ReadandWrites();
            h.Writing_Doctors_In_File(doctors);
            h.Writing_residentpatient_In_File(Rpatients);
            h.Writing_apppinmentpatients_In_File(Apatients);
            h.Writing_romm_In_File(rooms);
            h.write_nurse(nurses);
            h.Writing_appointments_In_File(appointments);
            h.Writing_departments_In_File(departments);
            h.Writing_semiprivateromm_In_File(Srooms);
            h.Writing_standardromm_In_File(STrooms);
            h.Writing_privateromm_In_File(Prooms);
            h.Writing_patients_In_File(patient);
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panel4.Visible = false;
            panel3.Visible = false;
            panel2.Visible = false;
            panel1.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {

            panel5.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
            comboBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            panel3.Visible = false;
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (doctors.Count > 0)
                D_ID = Convert.ToInt32(doctors[doctors.Count - 1].get_id()) + 1;
            else
                D_ID = 1;
            textBox1.Text = D_ID.ToString();
            for (int i = 0; i < departments.Count; i++)
            {

                comboBox1.Items.Add(departments[i].name);
            }
            textBox1.Text = Convert.ToString(D_ID);
            panel2.Visible = false;
            panel1.Visible = false;
            panel3.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < departments.Count; i++)
            {

                comboBox2.Items.Add(departments[i].name);
            }
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text = "";
            radioButton8.Checked = radioButton7.Checked = false;
            comboBox2.Text = "";
            panel1.Visible = false;
            panel2.Visible = true;
            panel4.Visible = false;
            panel3.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }



        private void button14_Click_1(object sender, EventArgs e)
        {

        }





        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox12.Text = "";
            label16.Visible = false;
            textBox12.Visible = false;
            panel6.Visible = false;
            panel1.Visible = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            label16.Visible = true;
            textBox12.Visible = true;
            button20.Visible = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {
                MessageBox.Show("some thing wrong , Please try again");
            }
            else
            {
                department d = new department();
                d.name = textBox12.Text;
                departments.Add(d);
                MessageBox.Show("Department Added");
                textBox12.Text = "";
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < departments.Count; i++)
            {

                comboBox3.Items.Add(departments[i].name);
            }
            textBox12.Text = "";
            button20.Visible = false;
            label16.Visible = false;
            textBox12.Visible = false;
            panel6.Visible = false;
            panel8.Visible = true;

        }



        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }



        private void button4_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
            panel1.Visible = false;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
            panel2.Visible = false;
            for (int i = 0; i < doctors.Count; i++)
            {
                ListViewItem v = new ListViewItem(doctors[i].get_id());
                v.SubItems.Add(doctors[i].get_name());
                v.SubItems.Add(doctors[i].get_address());
                v.SubItems.Add(doctors[i].get_age());
                v.SubItems.Add(doctors[i].get_phonenumber());
                v.SubItems.Add(doctors[i].departmentname);
                v.SubItems.Add(Convert.ToString(doctors[i].IsHead));
                listView1.Items.Add(v);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
            panel2.Visible = false;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            panel7.Visible = false;
            panel2.Visible = true;
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            button64.Visible = false;
            button65.Visible = false;
            button66.Visible = false;
            listView7.Items.Clear();
            listView6.Items.Clear();
            listView2.Items.Clear();
            listView2.Visible = false;
            listView7.Visible = false;
            listView6.Visible = false;
            panel8.Visible = false;
            panel6.Visible = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

            if (comboBox3.Text == "")
            { MessageBox.Show("something wrong , please try again"); }
            else
            {
                listView7.Items.Clear();
                listView6.Items.Clear();
                listView2.Items.Clear();
                listView7.Visible = false;
                listView6.Visible = false;
                listView2.Visible = false;


                for (int i = 0; i < departments.Count; i++)
                {
                    if (comboBox3.Text == departments[i].name)
                    {
                        button64.Visible = true;
                        button65.Visible = true;
                        button66.Visible = true;




                        for (int j = 0; j < doctors.Count; j++)
                        {

                            if (departments[i].name == doctors[j].departmentname)
                            {
                                ListViewItem v = new ListViewItem(doctors[j].get_id());
                                v.SubItems.Add(doctors[j].get_name());
                                if (doctors[j].IsHead == true)
                                {
                                    v.SubItems.Add(doctors[j].get_id());
                                    v.SubItems.Add(doctors[j].get_name());

                                }
                                listView2.Items.Add(v);
                            }


                        }
                        for (int y = 0; y < Rpatients.Count; y++)
                        {
                            if (departments[i].name == Rpatients[y].deparname)
                            {
                                ListViewItem v = new ListViewItem(Rpatients[y].get_id());
                                v.SubItems.Add(Rpatients[y].get_name());
                                listView6.Items.Add(v);

                            }

                        }
                        for (int y = 0; y < Apatients.Count; y++)
                        {
                            if (departments[i].name == Apatients[y].deparname)
                            {
                                ListViewItem v = new ListViewItem(Apatients[y].get_id());
                                v.SubItems.Add(Apatients[y].get_name());
                                listView6.Items.Add(v);

                            }

                        }
                        for (int q = 0; q < nurses.Count; q++)
                        {
                            if (departments[i].name == nurses[q].depart)
                            {
                                ListViewItem v = new ListViewItem(nurses[q].get_id());
                                v.SubItems.Add(nurses[q].get_name());
                                listView7.Items.Add(v);
                            }




                        }
                    }

                }
            }
        }






        private void button13_Click(object sender, EventArgs e)
        {
            bool inn = true;
            string depname = comboBox1.Text;
            bool head = radioButton1.Checked;
            string Dname = textBox2.Text;
            string Didd = textBox1.Text;
            string Dad = textBox3.Text;
            string Dag = textBox4.Text;
            string Dpn = textBox5.Text;
            for (int i = 0; i < departments.Count; i++)
            {
                if (depname == departments[i].name)
                {
                    if (departments[i].headdoctor == true && radioButton1.Checked == true)
                    {
                        MessageBox.Show("this department has a head , please try again");
                        inn = false;
                    }
                }
            }
            if (depname == "" || Didd == "" || Dad == "" || Dag == "" || Dpn == "" || depname == "" || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                inn = false;
                MessageBox.Show("Something Wrong , Please Try Again");
            }
            if (inn)
            {
                Hospitaal.doctor d = new doctor();
                d.set_name(Dname);
                d.set_id(Didd);
                d.set_age(Dag);
                d.set_address(Dad);
                d.set_phonenumber(Dpn);
                d.IsHead = head;
                d.departmentname = depname;
                for (int i = 0; i < departments.Count; i++)
                {
                    if (departments[i].name == depname)
                    {
                        departments[i].adddoctor(d);
                        if (head)
                        {
                            departments[i].head = d;
                            departments[i].sethead(d);
                        }
                    }
                }
                doctors.Add(d);


                MessageBox.Show("Doctor Added");
                textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
                comboBox1.Text = "";
                radioButton1.Checked = radioButton2.Checked = false;
                D_ID++;
                textBox1.Text = Convert.ToString(D_ID);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {

            bool inn = false;
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].get_id() == textBox6.Text)
                {
                    comboBox2.Text = doctors[i].getdepartment();
                    textBox7.Text = doctors[i].get_name();
                    textBox8.Text = doctors[i].get_address();
                    textBox9.Text = doctors[i].get_age();
                    textBox10.Text = doctors[i].get_phonenumber();
                    if (doctors[i].IsHead == true)
                    {
                        radioButton8.Checked = true;
                    }
                    else if (doctors[i].IsHead == false)
                    {
                        radioButton7.Checked = true;
                    }
                    //for (int j = 0; j < departments.Count; j++)
                    //{
                    //    if (departments[j].name == comboBox2.Text)
                    //    {

                    //        if (doctors[i].IsHead == true)
                    //        {

                    //            departments[j].headdoctor = false;
                    //            departments[j].head = null;
                    //        }
                    //        departments[j].doct.Remove(departments[j].doct[i]);

                    //    }
                    //}

                    inn = true;
                }



            }
            if (!inn)
            {
                MessageBox.Show("Doctor doesnot exist");
                textBox6.Text = comboBox2.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text = "";
                radioButton8.Checked = radioButton7.Checked = false;

            }

        }
        private void button6_Click(object sender, EventArgs e)
        {
            bool inn = true;

            for (int i = 0; i < departments.Count; i++)
            {
                if (comboBox2.Text == departments[i].name)
                {
                    if (departments[i].headdoctor == true && radioButton8.Checked == true)
                    {
                        MessageBox.Show("this department has a head , please try again");
                        inn = false;
                    }
                }
            }
            if (inn)
            {
                bool head = radioButton8.Checked;
                string depname = comboBox2.Text;
                string Dname = textBox7.Text;
                string Dad = textBox8.Text;
                string Dag = textBox9.Text;
                string Dpn = textBox10.Text;
                for (int i = 0; i < doctors.Count; i++)
                {

                    if (doctors[i].get_id() == textBox6.Text)
                    {
                        for (int j = 0; j < departments.Count; j++)
                        {
                            for (int x = 0; x < departments[j].doct.Count; x++)
                            {
                                if (departments[j].doct[x].get_id() == textBox6.Text)
                                {

                                    if (doctors[i].IsHead == true)
                                    {
                                        departments[j].headdoctor = false;
                                        departments[j].head = null;

                                    }

                                    departments[j].doct.Remove(departments[j].doct[x]);
                                }

                            }
                        }
                        doctors[i].set_address(Dad);
                        doctors[i].set_age(Dag);
                        doctors[i].set_name(Dname);
                        doctors[i].departmentname = depname;
                        doctors[i].set_phonenumber(Dpn);
                        doctors[i].IsHead = head;

                        //for (int j = 0; j < departments.Count; j++)
                        //{
                        //   for (int x = 0; x < departments[j].doct.Count; x++)
                        //        {
                        //            if (departments[j].doct[x].get_id() == textBox6.Text)
                        //            {

                        //                if (departments[j].doct[x].IsHead== true)
                        //                {

                        //                    departments[j].headdoctor = false;
                        //                    departments[j].head = null;
                        //                }
                        //                departments[j].doct.Remove(departments[j].doct[x]);

                        //            }
                        //        }

                        //}
                        for (int j = 0; j < departments.Count; j++)
                        {
                            if (departments[j].name == depname)
                            {
                                departments[j].adddoctor(doctors[i]);
                            }
                        }
                        if (head == true)
                        {
                            for (int j = 0; j < departments.Count; j++)
                            {
                                if (departments[j].name == depname)
                                {
                                    departments[j].head = doctors[i];
                                    departments[j].sethead(doctors[i]);

                                }
                            }
                        }
                        MessageBox.Show("Doctor Edited");
                    }


                }
                textBox6.Text = textBox7.Text = comboBox2.Text = textBox8.Text = textBox9.Text = textBox10.Text = "";
                radioButton8.Checked = radioButton7.Checked = false;
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            button44.Visible = false;
            button43.Visible = false;
            button39.Visible = false;
            button40.Visible = false;
            button30.Visible = false;
            button31.Visible = false;
            button81.Visible = button82.Visible = false;
            panel1.Visible = true;
            panel9.Visible = false;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            button81.Visible = button82.Visible = false;
            button44.Visible = false;
            button43.Visible = false;
            button39.Visible = false;
            button40.Visible = false;
            button30.Visible = true;
            button31.Visible = true;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (Rpatients.Count > 0)
                RP_ID = Convert.ToInt32(Rpatients[Rpatients.Count - 1].get_id()) + 1;
            else
                RP_ID = 50;
            textBox17.Text = RP_ID.ToString();
            for (int i = 0; i < departments.Count; i++)
            {
                comboBox5.Items.Add(departments[i].name);
            }
            panel9.Visible = false;
            panel10.Visible = true;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (Apatients.Count > 0)
                AP_ID = Convert.ToInt32(Apatients[Apatients.Count - 1].get_id()) + 1;
            else
                AP_ID = 100;
            textBox22.Text = AP_ID.ToString();
            comboBox21.Items.Clear();
            for (int i = 0; i < departments.Count; i++)
            {
                comboBox21.Items.Add(departments[i].name);
            }
            panel11.Visible = true;
            panel9.Visible = false;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            button81.Visible = button82.Visible = false;
            button44.Visible = false;
            button43.Visible = false;
            button39.Visible = true;
            button40.Visible = true;
            button30.Visible = false;
            button31.Visible = false;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            button81.Visible = button82.Visible = false;
            button44.Visible = true;
            button43.Visible = true;
            button39.Visible = false;
            button40.Visible = false;
            button30.Visible = false;
            button31.Visible = false;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            button81.Visible = button82.Visible = true;
            button44.Visible = false;
            button43.Visible = false;
            button39.Visible = false;
            button40.Visible = false;
            button30.Visible = false;
            button31.Visible = false;

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {
            textBox13.Text = textBox58.Text = textBox14.Text = comboBox4.Text = comboBox5.Text = textBox15.Text = textBox16.Text = textBox17.Text = textBox30.Text = textBox38.Text = "";
            comboBox24.Text = "";
            radioButton3.Checked = radioButton4.Checked = radioButton5.Checked = false;
            comboBox4.Items.Clear();
            comboBox24.Items.Clear();
            comboBox5.Items.Clear();
            panel9.Visible = true;
            panel10.Visible = false;
            button30.Visible = false;
            button31.Visible = false;
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button35_Click(object sender, EventArgs e)
        {

            panel9.Visible = true;
            panel1.Visible = false;
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void button35_Click_1(object sender, EventArgs e)
        {
            button30.Visible = button31.Visible = false;
            comboBox20.Text = comboBox17.Text = comboBox26.Text = "";
            textBox18.Text = textBox19.Text = textBox20.Text = textBox21.Text = textBox22.Text = textBox29.Text = comboBox21.Text = comboBox7.Text = comboBox18.Text = comboBox19.Text = textBox67.Text = "";
            comboBox7.Items.Clear();

            panel9.Visible = true;
            panel11.Visible = false;
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button38_Click(object sender, EventArgs e)
        {
            comboBox6.Text = textBox27.Text = textBox41.Text = textBox28.Text = textBox26.Text = textBox25.Text = textBox23.Text = textBox24.Text = textBox57.Text = comboBox14.Text = textBox78.Text = comboBox25.Text = "";
            radioButton11.Checked = radioButton12.Checked = radioButton6.Checked = false;
            comboBox6.Items.Clear();
            comboBox25.Items.Clear();
            comboBox14.Items.Clear();

            button39.Visible = button40.Visible = false;
            panel9.Visible = true;
            panel12.Visible = false;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Rpatients.Count; i++)
            {
                bool inn = false;
                if (textBox27.Text == Rpatients[i].get_id())
                {
                    if (radioButton12.Checked == true)
                    {
                        for (int j = 0; j < STrooms.Count; j++)
                        {
                            if (STrooms[j].Roomnumber == comboBox25.Text)
                            {
                                if (STrooms[j].full == false)
                                {
                                    STrooms[i].addPatient(Rpatients[i]);
                                    inn = true;
                                }
                                else
                                    MessageBox.Show("This room is full please choose another room");
                            }
                        }

                    }
                    if (radioButton11.Checked == true)
                    {
                        for (int j = 0; j < Srooms.Count; j++)
                        {
                            if (Srooms[j].Roomnumber == comboBox25.Text)
                            {
                                if (Srooms[j].full == false)
                                {
                                    Srooms[j].addPatient(Rpatients[i]);
                                    inn = true;
                                }
                                else
                                    MessageBox.Show("This room is full please choose another room");

                            }
                        }
                    }
                    if (radioButton6.Checked == true)
                    {
                        for (int j = 0; j < Prooms.Count; j++)
                        {
                            if (Prooms[j].Roomnumber == comboBox25.Text)
                            {
                                if (Prooms[j].full == false)
                                {
                                    Prooms[j].addPatient(Rpatients[i]);
                                    inn = true;
                                }
                                else
                                    MessageBox.Show("This room is full please choose another room");
                            }
                        }
                    }
                    if (inn)
                    {
                        Rpatients[i].deparname = comboBox6.Text;
                        Rpatients[i].set_name(textBox28.Text);
                        Rpatients[i].set_address(textBox26.Text);
                        Rpatients[i].set_age(textBox25.Text);
                        Rpatients[i].set_phonenumber(textBox23.Text);
                        Rpatients[i].medicaldiagonis = textBox24.Text;
                        Rpatients[i].medicinehistory = textBox57.Text;
                        Rpatients[i].bill = textBox78.Text;
                        Rpatients[i].room = comboBox25.Text;
                        Rpatients[i].nurs.Clear();
                        for (int j = 0; j < nurses.Count; j++)
                        {
                            for (int x = 0; x < nurses[j].l_patients.Count; x++)
                            {
                                if (nurses[j].l_patients[x].get_id() == textBox27.Text)
                                {
                                    nurses[j].l_patients.Remove(nurses[j].l_patients[x]);
                                }
                            }
                        }

                        for (int j = 0; j < doctors.Count; j++)
                        {
                            for (int x = 0; x < doctors[j].Repatients.Count; x++)
                            {
                                if (doctors[j].Repatients[x].get_id() == textBox27.Text)
                                {
                                    doctors[j].Repatients.Remove(doctors[j].Repatients[x]);
                                }
                            }
                        }
                        for (int j = 0; j < doctors.Count; j++)
                        {
                            if (doctors[j].get_id() == comboBox14.Text)
                            {
                                doctors[j].addresidentpatient(Rpatients[i]);
                                Rpatients[i].doc = doctors[j];
                            }
                        }
                        for (int j = 0; j < STrooms.Count; j++)
                        {
                            for (int x = 0; x < STrooms[j].Patients.Count; x++)
                            {
                                if (STrooms[j].Patients[x].get_id() == textBox27.Text)
                                {

                                    STrooms[j].Patients.Remove(STrooms[j].Patients[x]);
                                    STrooms[j].availableBeds++;
                                    STrooms[j].full = false;
                                }
                            }
                        }
                        for (int j = 0; j < Srooms.Count; j++)
                        {
                            for (int x = 0; x < Srooms[j].Patients.Count; x++)
                            {
                                if (Srooms[j].Patients[x].get_id() == textBox27.Text)
                                {
                                    Srooms[j].Patients.Remove(Srooms[j].Patients[x]);
                                    Srooms[j].availableBeds++;
                                    Srooms[j].full = false;
                                }
                            }
                        }
                        for (int j = 0; j < Prooms.Count; j++)
                        {
                            for (int x = 0; x < Prooms[j].Patients.Count; x++)
                            {
                                if (Prooms[j].Patients[x].get_id() == textBox27.Text)
                                {
                                    Prooms[j].Patients.Remove(Prooms[j].Patients[x]);
                                    Prooms[j].availableBeds++;
                                    Prooms[j].full = false;
                                }
                            }
                        }
                        if (radioButton12.Checked == true)
                        {
                            for (int j = 0; j < nurses.Count; j++)
                            {
                                for (int x = 0; x < nurses[j].S_room.Count; x++)
                                {
                                    if (nurses[j].S_room[x].Roomnumber == comboBox25.Text)
                                    {
                                        nurses[j].addpatient(Rpatients[i]);
                                        Rpatients[i].addnurse(nurses[j]);
                                    }
                                }
                            }
                        }
                        if (radioButton11.Checked == true)
                        {
                            for (int j = 0; j < nurses.Count; j++)
                            {
                                for (int x = 0; x < nurses[j].l_SemiPrivateRoom.Count; x++)
                                {
                                    if (nurses[j].l_SemiPrivateRoom[x].Roomnumber == comboBox25.Text)
                                    {
                                        nurses[j].addpatient(Rpatients[i]);
                                        Rpatients[i].addnurse(nurses[j]);
                                    }
                                }
                            }
                        }
                        if (radioButton6.Checked == true)
                        {
                            for (int j = 0; j < nurses.Count; j++)
                            {
                                for (int x = 0; x < nurses[j].l_PrivateRooms.Count; x++)
                                {
                                    if (nurses[j].l_PrivateRooms[x].Roomnumber == comboBox25.Text)
                                    {
                                        nurses[j].addpatient(Rpatients[i]);
                                        Rpatients[i].addnurse(nurses[j]);
                                    }
                                }
                            }
                        }

                        MessageBox.Show("patient edited");
                        comboBox6.Text = textBox27.Text = textBox41.Text = textBox28.Text = textBox26.Text = textBox25.Text = textBox23.Text = textBox24.Text = textBox57.Text = comboBox14.Text = textBox78.Text = comboBox25.Text = "";
                        radioButton11.Checked = radioButton12.Checked = radioButton6.Checked = false;
                        comboBox25.Items.Clear();
                        comboBox14.Items.Clear();
                    }
                }
            }

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void button32_Click(object sender, EventArgs e)
        {
            bool inn = false;
            if (textBox13.Text == "" || textBox14.Text == "" || textBox58.Text == "" || textBox15.Text == "" || textBox16.Text == "" || textBox17.Text == "" || /*textBox30.Text == "" || textBox38.Text == "" ||*/ comboBox24.Text == "" || (radioButton3.Checked == radioButton4.Checked == radioButton5.Checked == false))
            {
                MessageBox.Show("something wrong , please try again");
            }
            else
            {
                residentpatient r = new residentpatient();

                if (radioButton3.Checked == true)
                {
                    for (int i = 0; i < STrooms.Count; i++)
                    {
                        if (STrooms[i].Roomnumber == comboBox24.Text)
                        {
                            if (STrooms[i].full == false)
                            {
                                STrooms[i].addPatient(r);
                                inn = true;
                            }
                            else
                                MessageBox.Show("This room is full please choose another room");
                        }
                    }

                }
                if (radioButton4.Checked == true)
                {
                    for (int i = 0; i < Srooms.Count; i++)
                    {
                        if (Srooms[i].Roomnumber == comboBox24.Text)
                        {
                            if (Srooms[i].full == false)
                            {
                                Srooms[i].addPatient(r);
                                inn = true;
                            }
                            else
                                MessageBox.Show("This room is full please choose another room");

                        }
                    }
                }
                if (radioButton5.Checked == true)
                {
                    for (int i = 0; i < Prooms.Count; i++)
                    {
                        if (Prooms[i].Roomnumber == comboBox24.Text)
                        {
                            if (Prooms[i].full == false)
                            {
                                Prooms[i].addPatient(r);
                                inn = true;
                            }
                            else
                                MessageBox.Show("This room is full please choose another room");
                        }
                    }
                }
                if (inn)
                {

                    r.set_id(textBox17.Text);
                    r.set_name(textBox16.Text);
                    r.set_address(textBox15.Text);
                    r.set_age(textBox14.Text);
                    r.set_phonenumber(textBox13.Text);
                    r.medicaldiagonis = textBox30.Text;
                    r.deparname = comboBox5.Text;
                    r.room = comboBox24.Text;
                    r.bill = textBox77.Text;
                    r.medicinehistory = textBox38.Text;
                    if (radioButton3.Checked == true)
                    {
                        for (int i = 0; i < nurses.Count; i++)
                        {
                            for (int j = 0; j < nurses[i].S_room.Count; j++)
                            {
                                if (nurses[i].S_room[j].Roomnumber == comboBox24.Text)
                                {
                                    nurses[i].addpatient(r);
                                    r.addnurse(nurses[i]);
                                }
                            }
                        }
                    }
                    if (radioButton4.Checked == true)
                    {
                        for (int i = 0; i < nurses.Count; i++)
                        {
                            for (int j = 0; j < nurses[i].l_SemiPrivateRoom.Count; j++)
                            {
                                if (nurses[i].l_SemiPrivateRoom[j].Roomnumber == comboBox24.Text)
                                {
                                    nurses[i].addpatient(r);

                                    r.addnurse(nurses[i]);
                                }
                            }
                        }
                    }
                    if (radioButton5.Checked == true)
                    {
                        for (int i = 0; i < nurses.Count; i++)
                        {
                            for (int j = 0; j < nurses[i].l_PrivateRooms.Count; j++)
                            {
                                if (nurses[i].l_PrivateRooms[j].Roomnumber == comboBox24.Text)
                                {
                                    nurses[i].addpatient(r);
                                    r.addnurse(nurses[i]);
                                }
                            }
                        }
                    }
                    for (int i = 0; i < doctors.Count; i++)
                    {
                        if (doctors[i].get_id() == comboBox4.Text)
                        {
                            doctors[i].addresidentpatient(r);
                            r.doc = doctors[i];
                        }
                    }

                    Rpatients.Add(r);

                    MessageBox.Show("Patient has been added");

                    textBox13.Text = textBox14.Text = textBox15.Text = textBox58.Text = textBox16.Text = textBox30.Text = textBox38.Text = comboBox24.Text = comboBox4.Text = comboBox5.Text = "";
                    radioButton3.Checked = radioButton4.Checked = radioButton5.Checked = false;
                    RP_ID++;
                    textBox17.Text = Convert.ToString(RP_ID);

                }

            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            bool inn = false;
            for (int i = 0; i < Rpatients.Count; i++)
            {
                if (textBox27.Text == Rpatients[i].get_id())
                {
                    comboBox6.Text = Rpatients[i].deparname;
                    textBox28.Text = Rpatients[i].get_name();
                    textBox26.Text = Rpatients[i].get_address();
                    textBox25.Text = Rpatients[i].get_age();
                    textBox23.Text = Rpatients[i].get_phonenumber();
                    textBox24.Text = Rpatients[i].medicaldiagonis;
                    textBox57.Text = Rpatients[i].medicinehistory;
                    if (Rpatients[i].doc != null)
                        comboBox14.Text = Rpatients[i].doc.get_id();
                    else
                        comboBox1.Text = "";
                    textBox78.Text = Rpatients[i].bill;
                    comboBox25.Text = Rpatients[i].room;
                    if (Convert.ToInt32(Rpatients[i].room) < 100)
                    {
                        radioButton12.Checked = true;
                    }
                    if (Convert.ToInt32(Rpatients[i].room) < 200 && Convert.ToInt32(Rpatients[i].room) >= 100)
                    {
                        radioButton11.Checked = true;
                    }
                    if (Convert.ToInt32(Rpatients[i].room) < 300 && Convert.ToInt32(Rpatients[i].room) >= 200)
                    {
                        radioButton6.Checked = true;
                    }

                    inn = true;
                }
            }
            if (!inn)
            {
                MessageBox.Show("patient does not exist");
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            comboBox22.Items.Clear();
            for (int i = 0; i < departments.Count; i++)
            {
                comboBox22.Items.Add(departments[i].name);
            }
            panel14.Visible = true;
            panel9.Visible = false;

        }

        private void button42_Click(object sender, EventArgs e)
        {

        }

        private void button41_Click(object sender, EventArgs e)
        {
            button43.Visible = button44.Visible = false;
            panel13.Visible = false;
            panel9.Visible = true;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            listView3.Items.Clear();
            panel9.Visible = false;
            panel15.Visible = true;
            for (int i = 0; i < Apatients.Count; i++)
            {

                ListViewItem v = new ListViewItem(Apatients[i].get_id());
                v.SubItems.Add(Apatients[i].get_name());
                v.SubItems.Add(Apatients[i].get_address());
                v.SubItems.Add(Apatients[i].get_age());
                v.SubItems.Add(Apatients[i].get_phonenumber());
                v.SubItems.Add(Apatients[i].medicaldiagonis);
                v.SubItems.Add(Apatients[i].doc.get_id());
                v.SubItems.Add(Apatients[i].appointment.date);
                v.SubItems.Add((Apatients[i].appointment.Duration).ToString());
                v.SubItems.Add(Apatients[i].bill);
                listView3.Items.Add(v);

            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            button30.Visible = button31.Visible = false;
            comboBox9.Text = comboBox22.Text = comboBox27.Text = comboBox16.Text = comboBox15.Text = comboBox29.Text = comboBox28.Text = "";
            textBox31.Text = textBox32.Text = textBox33.Text = textBox34.Text = textBox35.Text = textBox36.Text = textBox37.Text = "";
            panel14.Visible = false;
            panel9.Visible = true;
        }

        private void button45_Click(object sender, EventArgs e)
        {
            bool inn = false;
            for (int i = 0; i < Apatients.Count; i++)
            {

                if (Apatients[i].get_id() == textBox37.Text)
                {
                    for (int j = 0; j < doctors.Count; j++)
                    {
                        for (int x = 0; x < doctors[j].Appointments.Count; x++)
                        {
                            if (doctors[j].Appointments[x].Patient != null)
                            {
                                if (doctors[j].Appointments[x].Patient.get_id() == textBox37.Text)
                                {
                                    doctors[j].Appointments.Remove(doctors[j].Appointments[x]);
                                }
                            }
                        }
                    }
                    for (int j = 0; j < appointments.Count; j++)
                    {
                        if (appointments[j].Patient.get_id() == textBox37.Text)
                        {
                            appointments[j].Patient = null;
                            appointments[j].Doctor = null;
                            appointments.Remove(appointments[j]);
                            
                        }
                    }
                    for (int j = 0; j < doctors.Count; j++)
                    {
                        for (int x = 0; x < doctors[j].Appatients.Count; x++)
                        {
                            if (doctors[j].Appatients[x].get_id() == textBox37.Text)
                            {
                                doctors[j].Appatients.Remove(doctors[j].Appatients[x]);
                            }
                        }
                    }
                   
                    appointment a = new appointment();
                    a.date = comboBox27.Text + "/" + comboBox16.Text + "/" + comboBox15.Text;
                    a.Duration = Convert.ToDouble(comboBox29.Text) + Convert.ToDouble(comboBox28.Text);


                    for (int j = 0; j < doctors.Count; j++)
                    {
                        if (doctors[j].get_id() == comboBox9.Text)
                        {
                            doctors[j].isfree(a);
                            if (doctors[j].free == true)
                            {
                                inn = true;

                            }
                            else if(doctors[j].free ==false)
                                MessageBox.Show("this appointment isnot free please chose another");
  
                            break;
                        }
                    }
                    if (inn)
                    {
                        Apatients[i].set_name(textBox36.Text);
                        Apatients[i].set_address(textBox35.Text);
                        Apatients[i].set_age(textBox34.Text);
                        Apatients[i].set_phonenumber(textBox33.Text);
                        Apatients[i].medicaldiagonis = textBox32.Text;
                        Apatients[i].deparname = comboBox22.Text;
                        Apatients[i].appointment = a;
                        Apatients[i].bill = textBox31.Text;
                        comboBox9.Items.Clear();
                        a.addpatient(Apatients[i]);
                        Apatients[i].appointment = a;
                        appointments.Add(a);
                        for (int j = 0; j < doctors.Count; j++)
                        {
                            if (doctors[j].get_id() == comboBox9.Text)
                            {
                                a.adddoctor(doctors[j]);
                                doctors[j].addappointmentpatient(Apatients[i]);
                                doctors[j].addAppointment(a);
                                Apatients[i].doc = doctors[j];

                            }
                        }
                        MessageBox.Show("patient editet");
                        comboBox9.Text = comboBox22.Text = comboBox27.Text = comboBox16.Text = comboBox15.Text = comboBox29.Text = comboBox28.Text = "";
                        textBox31.Text = textBox32.Text = textBox33.Text = textBox34.Text = textBox35.Text = textBox36.Text = textBox37.Text = "";
                    }
                }
            }
                
            }
        

        private void button44_Click(object sender, EventArgs e)
        {
            panel16.Visible = true;
            panel9.Visible = false;
            for (int i = 0; i < Rpatients.Count; i++)
            {
                ListViewItem v = new ListViewItem(Rpatients[i].get_id());
                v.SubItems.Add(Rpatients[i].get_name());
                v.SubItems.Add(Rpatients[i].get_address());
                v.SubItems.Add(Rpatients[i].get_age());
                v.SubItems.Add(Rpatients[i].get_phonenumber());
                v.SubItems.Add(Rpatients[i].room);
                v.SubItems.Add(Rpatients[i].medicinehistory);
                v.SubItems.Add(Rpatients[i].medicaldiagonis);
                if (Rpatients[i].doc != null)
                {
                    v.SubItems.Add(Rpatients[i].doc.get_id());
                }
                else
                    v.SubItems.Add("");
                v.SubItems.Add(Rpatients[i].bill);
                listView4.Items.Add(v);
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < departments.Count; i++)
            {
                comboBox6.Items.Add(departments[i].name);
            }
            panel9.Visible = false;
            panel12.Visible = true;
        }

        private void button47_Click(object sender, EventArgs e)
        {
            button44.Visible = button43.Visible = false;
            panel9.Visible = true;
            panel15.Visible = false;
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button48_Click(object sender, EventArgs e)
        {
            listView4.Items.Clear();
            button43.Visible = button44.Visible = false;
            panel16.Visible = false;
            panel9.Visible = true;

        }

        private void button49_Click(object sender, EventArgs e)
        {
            bool inn = false;
            for (int i = 0; i < Apatients.Count; i++)
            {
                if (Apatients[i].get_id() == textBox37.Text)
                {
                    comboBox22.Text = Apatients[i].deparname;
                    textBox36.Text = Apatients[i].get_name();
                    textBox35.Text = Apatients[i].get_address();
                    textBox34.Text = Apatients[i].get_age();
                    textBox33.Text = Apatients[i].get_phonenumber();
                    textBox32.Text = Apatients[i].medicaldiagonis;
                    comboBox9.Text = Apatients[i].doc.get_id();
                    textBox31.Text = Apatients[i].bill;
                    string x = Apatients[i].appointment.date;
                    comboBox27.Text = x[0].ToString() + x[1].ToString();
                    comboBox16.Text = x[3].ToString() + x[4].ToString();
                    comboBox15.Text = x[6].ToString() + x[7].ToString();
                    int a = Convert.ToInt16(Apatients[i].appointment.Duration);
                    double b = Apatients[i].appointment.Duration - a;
                    comboBox29.Text = a.ToString();
                    comboBox28.Text = b.ToString();


                    inn = true;
                }
            }
            if (!inn)
            {
                MessageBox.Show("Patient doesnot exist");
                textBox37.Text = "";
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            checkedListBox3.Items.Clear();
            checkedListBox4.Items.Clear();
            checkedListBox5.Items.Clear();
            checkedListBox6.Items.Clear();
            checkedListBox7.Items.Clear();
            checkedListBox8.Items.Clear();
            checkedListBox9.Items.Clear();
            panel1.Visible = true;
            panel17.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < STrooms.Count; i++)
            {
                checkedListBox1.Items.Add(STrooms[i].Roomnumber);
            }
            for (int i = 0; i < Srooms.Count; i++)
            {
                checkedListBox2.Items.Add(Srooms[i].Roomnumber);
            }
            for (int i = 0; i < Prooms.Count; i++)
            {
                checkedListBox3.Items.Add(Prooms[i].Roomnumber);
            }
            for (int i = 0; i < STrooms.Count; i++)
            {
                checkedListBox6.Items.Add(STrooms[i].Roomnumber);
            }
            for (int i = 0; i < Srooms.Count; i++)
            {
                checkedListBox5.Items.Add(Srooms[i].Roomnumber);
            }
            for (int i = 0; i < Prooms.Count; i++)
            {
                checkedListBox4.Items.Add(Prooms[i].Roomnumber);
            }
            for (int i = 0; i < STrooms.Count; i++)
            {
                checkedListBox9.Items.Add(STrooms[i].Roomnumber);
            }
            for (int i = 0; i < Srooms.Count; i++)
            {
                checkedListBox8.Items.Add(Srooms[i].Roomnumber);
            }
            for (int i = 0; i < Prooms.Count; i++)
            {
                checkedListBox7.Items.Add(Prooms[i].Roomnumber);
            }
            panel17.Visible = true;
            panel1.Visible = false;
        }

        private void button55_Click(object sender, EventArgs e)
        {
            listView5.Items.Clear();
            listView8.Items.Clear();
            listView9.Items.Clear();
            panel17.Visible = true;
            panel18.Visible = false;
            listView9.Visible = false;
            listView8.Visible = false;
            listView5.Visible = false;


        }

        private void button53_Click(object sender, EventArgs e)
        {
            panel17.Visible = false;
            panel18.Visible = true;
            int count = 0;
            int c = 0;
            for (int i = 0; i < nurses.Count; i++)
            {
                ListViewItem v = new ListViewItem(nurses[i].get_id());
                v.SubItems.Add(nurses[i].get_name());
                v.SubItems.Add(nurses[i].get_age());
                v.SubItems.Add(nurses[i].get_address());
                v.SubItems.Add(nurses[i].get_phonenumber());
                v.SubItems.Add(nurses[i].depart);
                listView5.Items.Add(v);
            }

            for (int i = 0; i < nurses.Count; i++)
            {
                for (int j = 0; j < nurses[i].S_room.Count; j++)
                {
                    listView8.Items.Insert(count, (nurses[i].get_id() + "  /  " + nurses[i].S_room[j].Roomnumber));
                    count++;

                }
            }
            for (int i = 0; i < nurses.Count; i++)
            {
                for (int j = 0; j < nurses[i].l_SemiPrivateRoom.Count; j++)
                {
                    listView8.Items.Insert(count, (nurses[i].get_id() + "  /  " + nurses[i].l_SemiPrivateRoom[j].Roomnumber));
                    count++;

                }
            }
            for (int i = 0; i < nurses.Count; i++)
            {
                for (int j = 0; j < nurses[i].l_PrivateRooms.Count; j++)
                {
                    listView8.Items.Insert(count, (nurses[i].get_id() + "  /  " + nurses[i].l_PrivateRooms[j].Roomnumber));
                    count++;
                }
            }
            for (int i = 0; i < nurses.Count; i++)
            {
                for (int j = 0; j < nurses[i].l_patients.Count; j++)
                {
                    listView9.Items.Insert(c, (nurses[i].get_id() + "  /  " + nurses[i].l_patients[j].get_id()));
                    c++;
                }
            }
        }

        private void button58_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox4.Items.Count; i++)
            {
                checkedListBox4.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBox5.Items.Count; i++)
            {
                checkedListBox5.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBox6.Items.Count; i++)
            {
                checkedListBox6.SetItemChecked(i, false);
            }

            comboBox10.Items.Clear();
            textBox44.Text = textBox43.Text = textBox42.Text = textBox40.Text = textBox39.Text = comboBox10.Text = "";
            panel19.Visible = false;
            panel17.Visible = true;
        }

        private void button50_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < departments.Count; i++)
            {
                comboBox10.Items.Add(departments[i].name);
            }
            panel17.Visible = false;
            panel19.Visible = true;
        }

        private void button60_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                checkedListBox3.SetItemChecked(i, false);
            }
            comboBox11.Items.Clear();
            textBox46.Text = textBox47.Text = textBox48.Text = textBox49.Text = textBox50.Text = comboBox11.Text = "";
            panel20.Visible = false;
            panel17.Visible = true;
        }

        private void button52_Click(object sender, EventArgs e)
        {
            if (nurses.Count > 0)
                N_ID = Convert.ToInt32(nurses[nurses.Count - 1].get_id()) + 1;
            else
                N_ID = 150;
            textBox1.Text = N_ID.ToString();
            textBox50.Text = Convert.ToString(N_ID);
            for (int i = 0; i < departments.Count; i++)
            {

                comboBox11.Items.Add(departments[i].name);
            }
            panel17.Visible = false;
            panel20.Visible = true;
        }

        private void button54_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < departments.Count; i++)
            {

                comboBox13.Items.Add(departments[i].name);
            }
            panel17.Visible = false;
            panel21.Visible = true;
        }

        private void button61_Click(object sender, EventArgs e)
        {
            textBox52.Text = "";
            panel21.Visible = false;
            panel17.Visible = true;
        }

        private void button62_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Patient Deleted.");
        }

        private void button63_Click(object sender, EventArgs e)
        {
            comboBox12.Items.Clear();
            textBox11.Text = "";
            textBox53.Text = textBox54.Text = textBox55.Text = textBox56.Text = comboBox12.Text = "";
            panel1.Visible = false;
            panel5.Visible = false;
            panel4.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void button14_Click_3(object sender, EventArgs e)
        {
            bool inn = false;
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].get_id() == textBox56.Text)
                {
                    comboBox12.Text = doctors[i].departmentname;
                    textBox55.Text = doctors[i].get_name();
                    textBox54.Text = doctors[i].get_address();
                    textBox53.Text = doctors[i].get_age();
                    textBox11.Text = doctors[i].get_phonenumber();
                    if (doctors[i].IsHead == true)
                    {
                        radioButton10.Checked = true;
                    }
                    else if (doctors[i].IsHead == false)
                    {
                        radioButton9.Checked = true;
                    }
                    inn = true;
                    break;
                }
            }
            if (!inn)
            {
                MessageBox.Show("Doctor doesnot exist");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].get_id() == textBox56.Text)
                {
                    for (int j = 0; j < Rpatients.Count; j++)
                    {
                        if (Rpatients[j].doc.get_id() == textBox56.Text)
                        {
                            Rpatients[j].doc = null;
                        }
                    }
                    for (int j = 0; j < Apatients.Count; j++)
                    {
                        if (Apatients[j].doc.get_id() == textBox56.Text)
                        {
                            Apatients[j].doc = null;
                        }

                    }
                    for (int j = 0; j < departments.Count; j++)
                    {
                        for (int x = 0; x < departments[j].doct.Count; x++)
                        {
                            if (departments[j].doct[x].get_id() == textBox56.Text)
                            {
                                if (doctors[i].IsHead == true)
                                {
                                    departments[j].headdoctor = false;
                                    departments[j].head = null;

                                }

                                departments[j].doct.Remove(departments[j].doct[x]);
                            }

                        }
                    }
                    doctors.Remove(doctors[i]);
                    MessageBox.Show("doctor deleted");
                    textBox11.Text = textBox53.Text = textBox54.Text = textBox55.Text = textBox56.Text = comboBox12.Text = "";
                    radioButton9.Checked = radioButton10.Checked = false;


                }

            }
        }

        private void button64_Click(object sender, EventArgs e)
        {
            listView2.Visible = true;
            listView6.Visible = false;
            listView7.Visible = false;
        }

        private void button65_Click(object sender, EventArgs e)
        {
            listView2.Visible = false;
            listView7.Visible = false;
            listView6.Visible = true;
        }

        private void button66_Click(object sender, EventArgs e)
        {
            listView7.Visible = true;
            listView6.Visible = false;
            listView2.Visible = false;
        }

        private void button59_Click(object sender, EventArgs e)
        {
            bool inn = false;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                { inn = true; }
            }
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                if (checkedListBox2.GetItemCheckState(i) == CheckState.Checked)
                { inn = true; }
            }
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                if (checkedListBox3.GetItemCheckState(i) == CheckState.Checked)
                { inn = true; }
            }

            if (textBox46.Text == "" || textBox47.Text == "" || textBox48.Text == "" || textBox49.Text == "" || comboBox11.Text == "" || inn == false)
            {
                MessageBox.Show("Something wrong , Please try again");
            }
            else
            {

                nurse n = new nurse();
                n.set_id(textBox50.Text);
                n.set_name(textBox49.Text);
                n.set_age(textBox47.Text);
                n.set_address(textBox48.Text);
                n.set_phonenumber(textBox46.Text);
                n.depart = comboBox11.Text;
                for (int i = 0; i < departments.Count; i++)
                {
                    if (departments[i].name == comboBox11.Text)
                    {
                        departments[i].addnurse(n);
                    }
                }
                for (int i = 0; i < STrooms.Count; i++)
                {
                    for (int j = 0; j < checkedListBox1.Items.Count; j++)
                    {
                        if (checkedListBox1.GetItemCheckState(j) == CheckState.Checked)
                        {
                            if (STrooms[i].Roomnumber == checkedListBox1.Items[j].ToString())
                            {
                                n.addstandardroom(STrooms[i]);
                                STrooms[i].addNurse(n);

                            }
                        }
                    }

                }
                for (int i = 0; i < Srooms.Count; i++)
                {
                    for (int j = 0; j < checkedListBox2.Items.Count; j++)
                    {
                        if (checkedListBox2.GetItemCheckState(j) == CheckState.Checked)
                        {
                            if (Srooms[i].Roomnumber == checkedListBox2.Items[j].ToString())
                            {
                                n.addsemiprivateroom(Srooms[i]);
                                Srooms[i].addNurse(n);

                            }
                        }
                    }

                }
                for (int i = 0; i < Prooms.Count; i++)
                {
                    for (int j = 0; j < checkedListBox3.Items.Count; j++)
                    {
                        if (checkedListBox3.GetItemCheckState(j) == CheckState.Checked)
                        {
                            if (Prooms[i].Roomnumber == checkedListBox3.Items[j].ToString())
                            {
                                n.addprivateroom(Prooms[i]);
                                Prooms[i].addNurse(n);

                            }
                        }
                    }

                }
                nurses.Add(n);



                MessageBox.Show("Nurse Added");
                N_ID++;
                textBox1.Text = Convert.ToString(N_ID);
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    checkedListBox2.SetItemChecked(i, false);
                }
                for (int i = 0; i < checkedListBox3.Items.Count; i++)
                {
                    checkedListBox3.SetItemChecked(i, false);
                }
                textBox46.Text = textBox47.Text = textBox48.Text = textBox49.Text = "";
                comboBox11.Text = "";
                textBox50.Text = Convert.ToString(N_ID);
            }


        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button71_Click(object sender, EventArgs e)
        {
            button70.Visible = button73.Visible = button72.Visible = true;
        }

        private void button69_Click(object sender, EventArgs e)
        {
            textBox51.Visible = textBox59.Visible = textBox60.Visible = false;
            button68.Visible = button74.Visible = button75.Visible = false;
            button70.Visible = button73.Visible = button72.Visible = false;
            label80.Visible = label81.Visible = label82.Visible = false;
            panel1.Visible = true;
            panel22.Visible = false;
        }

        private void button67_Click(object sender, EventArgs e)
        {
            panel22.Visible = true;
            panel1.Visible = false;
        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button70_Click(object sender, EventArgs e)
        {
            textBox51.Text = standard_Room_number.ToString();
            label80.Visible = textBox51.Visible = button68.Visible = true;
            label81.Visible = textBox59.Visible = button74.Visible = false;
            label82.Visible = textBox60.Visible = button75.Visible = false;

        }

        private void button73_Click(object sender, EventArgs e)
        {
            textBox59.Text = semiprivate_Room_number.ToString();
            label80.Visible = textBox51.Visible = button68.Visible = false;
            label81.Visible = textBox59.Visible = button74.Visible = true;
            label82.Visible = textBox60.Visible = button75.Visible = false;
        }

        private void button72_Click(object sender, EventArgs e)
        {
            textBox60.Text = private_room_number.ToString();
            label80.Visible = textBox51.Visible = button68.Visible = false;
            label81.Visible = textBox59.Visible = button74.Visible = false;
            label82.Visible = textBox60.Visible = button75.Visible = true;
        }

        private void button68_Click(object sender, EventArgs e)
        {
            standardRoom r = new standardRoom();
            room x = new room();
            x.Roomnumber = textBox51.Text;
            rooms.Add(x);
            r.Roomnumber = textBox51.Text;
            STrooms.Add(r);
            standard_Room_number++;
            textBox51.Text = standard_Room_number.ToString();
            MessageBox.Show("Room Added");


        }

        private void button74_Click(object sender, EventArgs e)
        {
            room x = new room();
            x.Roomnumber = textBox59.Text;
            rooms.Add(x);
            SemiPrivateRoom s = new SemiPrivateRoom();
            s.Roomnumber = textBox59.Text;
            Srooms.Add(s);
            semiprivate_Room_number++;
            textBox59.Text = semiprivate_Room_number.ToString();
            MessageBox.Show("Room Added");
        }

        private void button75_Click(object sender, EventArgs e)
        {
            room x = new room();
            x.Roomnumber = textBox60.Text;
            rooms.Add(x);
            PrivateRoom p = new PrivateRoom();
            p.Roomnumber = textBox60.Text;
            Prooms.Add(p);
            private_room_number++;
            textBox60.Text = private_room_number.ToString();
            MessageBox.Show("Room Added");
        }

        private void textBox60_TextChanged(object sender, EventArgs e)
        {

        }

        private void button56_Click(object sender, EventArgs e)
        {
            bool inn = false;
            for (int i = 0; i < nurses.Count; i++)
            {
                if (nurses[i].get_id() == textBox44.Text)
                {
                    textBox43.Text = nurses[i].get_name();
                    textBox42.Text = nurses[i].get_address();
                    textBox40.Text = nurses[i].get_age();
                    textBox39.Text = nurses[i].get_phonenumber();
                    comboBox10.Text = nurses[i].depart;
                    for (int j = 0; j < nurses[i].S_room.Count; j++)
                    {
                        checkedListBox6.SetItemChecked(Convert.ToInt32(nurses[i].S_room[j].Roomnumber) - 1, true);

                    }
                    for (int j = 0; j < nurses[i].l_SemiPrivateRoom.Count; j++)
                    {
                        checkedListBox5.SetItemChecked(Convert.ToInt32(nurses[i].l_SemiPrivateRoom[j].Roomnumber) - 100, true);
                    }
                    for (int j = 0; j < nurses[i].l_PrivateRooms.Count; j++)
                    {
                        checkedListBox4.SetItemChecked(Convert.ToInt32(nurses[i].l_PrivateRooms[j].Roomnumber) - 200, true);
                    }
                    inn = true;
                }


            }
            if (!inn)
            {
                MessageBox.Show("Nurse doesnot exist");
            }
        }

        private void button76_Click(object sender, EventArgs e)
        {
            textBox61.Text = textBox62.Text = textBox63.Text = textBox61.Text = textBox52.Text = textBox45.Text = comboBox13.Text = "";
            panel17.Visible = true;
            panel21.Visible = false;
            comboBox13.Items.Clear();
        }

        private void button61_Click_1(object sender, EventArgs e)
        {
            bool inn = false;
            for (int i = 0; i < nurses.Count; i++)
            {
                if (nurses[i].get_id() == textBox63.Text)
                {
                    textBox62.Text = nurses[i].get_name();
                    textBox61.Text = nurses[i].get_address();
                    textBox52.Text = nurses[i].get_age();
                    textBox45.Text = nurses[i].get_phonenumber();
                    comboBox13.Text = nurses[i].depart;
                    for (int j = 0; j < nurses[i].S_room.Count; j++)
                    {
                        checkedListBox9.SetItemChecked(Convert.ToInt32(nurses[i].S_room[j].Roomnumber) - 1, true);

                    }
                    for (int j = 0; j < nurses[i].l_SemiPrivateRoom.Count; j++)
                    {
                        checkedListBox8.SetItemChecked(Convert.ToInt32(nurses[i].l_SemiPrivateRoom[j].Roomnumber) - 100, true);
                    }
                    for (int j = 0; j < nurses[i].l_PrivateRooms.Count; j++)
                    {
                        checkedListBox7.SetItemChecked(Convert.ToInt32(nurses[i].l_PrivateRooms[j].Roomnumber) - 200, true);
                    }
                    inn = true;
                }


            }
            if (!inn)
            {
                MessageBox.Show("Nurse doesnot exist");
            }
        }

        private void button62_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < nurses.Count; i++)
            {
                if (nurses[i].get_id() == textBox63.Text)
                {
                    for (int j = 0; j < Rpatients.Count; j++)
                    {
                        for (int x = 0; x < Rpatients[j].nurs.Count; x++)
                        {
                            if (Rpatients[j].nurs[x].get_id() == textBox63.Text)
                            {
                                Rpatients[j].nurs.Remove(Rpatients[j].nurs[x]);
                            }
                        }
                    }
                    for (int j = 0; j < STrooms.Count; j++)
                    {
                        for (int x = 0; x < STrooms[j].Nurses.Count; x++)
                        {
                            if (STrooms[j].Nurses[x].get_id() == textBox63.Text)
                            {
                                STrooms[j].Nurses.Remove(STrooms[j].Nurses[x]);
                            }
                        }
                    }
                    for (int j = 0; j < Srooms.Count; j++)
                    {
                        for (int x = 0; x < Srooms[j].Nurses.Count; x++)
                        {
                            if (Srooms[j].Nurses[x].get_id() == textBox63.Text)
                            {
                                Srooms[j].Nurses.Remove(Srooms[j].Nurses[x]);
                            }
                        }
                    }
                    for (int j = 0; j < Prooms.Count; j++)
                    {
                        for (int x = 0; x < Prooms[j].Nurses.Count; x++)
                        {
                            if (Prooms[j].Nurses[x].get_id() == textBox63.Text)
                            {
                                Prooms[j].Nurses.Remove(Prooms[j].Nurses[x]);
                            }
                        }
                    }
                    nurses.Remove(nurses[i]);
                    MessageBox.Show("Nurse deleted");
                    textBox61.Text = textBox62.Text = textBox63.Text = textBox61.Text = textBox52.Text = textBox45.Text = comboBox13.Text = "";
                }
            }
        }

        private void button77_Click(object sender, EventArgs e)
        {

            listView5.Visible = true;
            listView8.Visible = false;
            listView9.Visible = false;

        }

        private void button78_Click(object sender, EventArgs e)
        {

            listView9.Visible = false;
            listView8.Visible = true;
            listView5.Visible = false;
        }

        private void button79_Click(object sender, EventArgs e)
        {
            listView9.Visible = true;
            listView8.Visible = false;
            listView5.Visible = false;

        }

        private void button57_Click(object sender, EventArgs e)
        {
            bool inn = false;
            for (int i = 0; i < nurses.Count; i++)
            {

                if (nurses[i].get_id() == textBox44.Text)
                {

                    nurses[i].S_room.Clear();
                    nurses[i].l_SemiPrivateRoom.Clear();
                    nurses[i].l_PrivateRooms.Clear();
                    nurses[i].set_name(textBox43.Text);
                    nurses[i].set_age(textBox40.Text);
                    nurses[i].set_address(textBox42.Text);
                    nurses[i].set_phonenumber(textBox39.Text);
                    nurses[i].depart = comboBox10.Text;
                    for (int j = 0; j < STrooms.Count; j++)
                    {
                        for (int x = 0; x < STrooms[j].Nurses.Count; x++)
                        {
                            if (STrooms[j].Nurses[x].get_id() == textBox44.Text)
                            {
                                STrooms[j].Nurses.Remove(STrooms[j].Nurses[x]);
                            }
                        }
                    }
                    for (int j = 0; j < Srooms.Count; j++)
                    {
                        for (int x = 0; x < Srooms[j].Nurses.Count; x++)
                        {
                            if (Srooms[j].Nurses[x].get_id() == textBox44.Text)
                            {
                                Srooms[j].Nurses.Remove(Srooms[j].Nurses[x]);
                            }
                        }
                    }
                    for (int j = 0; j < Prooms.Count; j++)
                    {
                        for (int x = 0; x < Prooms[j].Nurses.Count; x++)
                        {
                            if (Prooms[j].Nurses[x].get_id() == textBox44.Text)
                            {
                                Prooms[j].Nurses.Remove(Prooms[j].Nurses[x]);
                            }
                        }
                    }
                    for (int j = 0; j < STrooms.Count; j++)
                    {
                        for (int x = 0; x < checkedListBox6.Items.Count; x++)
                        {
                            if (checkedListBox6.GetItemCheckState(x) == CheckState.Checked)
                            {
                                if (STrooms[j].Roomnumber == checkedListBox6.Items[x].ToString())
                                {
                                    nurses[i].addstandardroom(STrooms[j]);
                                    STrooms[j].addNurse(nurses[i]);

                                }
                            }
                        }

                    }
                    for (int j = 0; j < Srooms.Count; j++)
                    {
                        for (int x = 0; x < checkedListBox5.Items.Count; x++)
                        {
                            if (checkedListBox5.GetItemCheckState(x) == CheckState.Checked)
                            {
                                if (Srooms[j].Roomnumber == checkedListBox5.Items[x].ToString())
                                {
                                    nurses[i].addsemiprivateroom(Srooms[j]);
                                    Srooms[j].addNurse(nurses[i]);

                                }
                            }
                        }

                    }
                    for (int j = 0; j < Prooms.Count; j++)
                    {
                        for (int x = 0; x < checkedListBox4.Items.Count; x++)
                        {
                            if (checkedListBox4.GetItemCheckState(x) == CheckState.Checked)
                            {
                                if (Prooms[j].Roomnumber == checkedListBox4.Items[x].ToString())
                                {
                                    nurses[i].addprivateroom(Prooms[j]);
                                    Prooms[j].addNurse(nurses[i]);

                                }
                            }
                        }

                    }
                    /* for (int j = 0; j < nurses[i].S_room.Count; j++)
                     {
                         for (int y = 0; y < checkedListBox6.Items.Count; y++)
                         {
                             if (checkedListBox6.GetItemCheckState(i) == CheckState.Checked)
                             {
                                 nurses[i].S_room[j].Roomnumber = checkedListBox6.Items[i].ToString();
                             }
                         }
                        

                     }
                     for (int j = 0; j < nurses[i].l_SemiPrivateRoom.Count; j++)
                     {
                         for (int y = 0; y < checkedListBox5.Items.Count; y++)
                         {
                             if (checkedListBox5.GetItemCheckState(y) == CheckState.Checked)
                             {
                                 nurses[i].l_SemiPrivateRoom[j].Roomnumber = checkedListBox5.Items[y].ToString();
                             }

                         }

                     }
                     for (int j = 0; j < nurses[i].l_PrivateRooms.Count; j++)
                     {
                         for (int y = 0; y < checkedListBox4.Items.Count; y++)
                         {
                             if (checkedListBox4.GetItemCheckState(y) == CheckState.Checked)
                             {
                                 nurses[i].l_PrivateRooms[j].Roomnumber = checkedListBox4.Items[y].ToString();
                             }

                         }

                     }*/

                    MessageBox.Show("Nurse Edited");
                    textBox39.Text = textBox40.Text = textBox42.Text = textBox43.Text = comboBox10.Text = textBox44.Text = "";
                    for (int x = 0; x < checkedListBox4.Items.Count; x++)
                    
                        checkedListBox4.SetItemChecked(x, false);
                    }
                    for (int x = 0; x < checkedListBox5.Items.Count; x++)
                    {
                        checkedListBox5.SetItemChecked(x, false);
                    }
                    for (int x = 0; x < checkedListBox6.Items.Count; x++)
                    {
                        checkedListBox6.SetItemChecked(x, false);
                    }
                    inn = true;
                }
                if (!inn)
                    MessageBox.Show("Nurse doesenot exist");
            }





        

        private void textBox43_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button80_Click(object sender, EventArgs e)
        {
            textBox70.Text = textBox66.Text = textBox69.Text = textBox68.Text = textBox65.Text = comboBox8.Text = "";
            panel9.Visible = true;
            panel13.Visible = false;
            button81.Visible = button82.Visible = false;
        }

        private void button82_Click(object sender, EventArgs e)
        {
            panel9.Visible = false;
            panel13.Visible = true;
        }

        private void button85_Click(object sender, EventArgs e)
        {
            button81.Visible=button82.Visible = false;
            panel9.Visible = true;
            panel23.Visible = false;
            textBox76.Text = textBox73.Text = comboBox23.Text = textBox75.Text = textBox74.Text = textBox72.Text = "";
        }

        private void button81_Click(object sender, EventArgs e)
        {
            panel9.Visible = false;
            panel23.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            comboBox24.Items.Clear();

            for (int i = 0; i < STrooms.Count; i++)
            {

                comboBox24.Items.Add(STrooms[i].Roomnumber);

            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

            comboBox24.Items.Clear();

            for (int i = 0; i < Srooms.Count; i++)
            {

                comboBox24.Items.Add(Srooms[i].Roomnumber);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

            comboBox24.Items.Clear();
            for (int i = 0; i < Prooms.Count; i++)
            {

                comboBox24.Items.Add(Prooms[i].Roomnumber);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].departmentname == comboBox5.Text)
                {

                    comboBox4.Items.Add(doctors[i].get_id());

                }
            }
        }

        private void button86_Click(object sender, EventArgs e)
        {

        }

        private void textBox77_TextChanged(object sender, EventArgs e)
        {



        }

        private void textBox58_TextChanged(object sender, EventArgs e)
        {
            textBox77.Text = "";
            if (radioButton3.Checked == true)
            {
                if (textBox58.Text != "")
                {
                    int x = STrooms[0].price * Convert.ToInt32(textBox58.Text);
                    textBox77.Text = x.ToString();
                }
            }
            if (radioButton4.Checked == true)
            {
                if (textBox58.Text != "")
                {
                    int x = Srooms[0].price * Convert.ToInt32(textBox58.Text);
                    textBox77.Text = x.ToString();
                }
            }
            if (radioButton5.Checked == true)
            {
                if (textBox58.Text != "")
                {
                    int x = Prooms[0].price * Convert.ToInt32(textBox58.Text);
                    textBox77.Text = x.ToString();
                }
            }
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            comboBox25.Items.Clear();

            for (int i = 0; i < STrooms.Count; i++)
            {

                comboBox25.Items.Add(STrooms[i].Roomnumber);

            }
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            comboBox25.Items.Clear();

            for (int i = 0; i < Srooms.Count; i++)
            {

                comboBox25.Items.Add(Srooms[i].Roomnumber);
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            comboBox25.Items.Clear();
            for (int i = 0; i < Prooms.Count; i++)
            {

                comboBox25.Items.Add(Prooms[i].Roomnumber);
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox14.Items.Clear();
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].departmentname == comboBox6.Text)
                {

                    comboBox14.Items.Add(doctors[i].get_id());

                }
            }
        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {
            textBox78.Text = "";
            if (radioButton12.Checked == true)
            {
                if (textBox41.Text != "")
                {
                    int x = STrooms[0].price * Convert.ToInt32(textBox41.Text);
                    textBox78.Text = x.ToString();
                }
            }
            if (radioButton11.Checked == true)
            {

                if (textBox41.Text != "")
                {
                    int x = Srooms[0].price * Convert.ToInt32(textBox41.Text);
                    textBox78.Text = x.ToString();
                }
            }
            if (radioButton6.Checked == true)
            {
                if (textBox41.Text != "")
                {
                    int x = Prooms[0].price * Convert.ToInt32(textBox41.Text);
                    textBox78.Text = x.ToString();
                }
            }
        }

        private void button41_Click_1(object sender, EventArgs e)
        {
            bool inn = false;
            for (int i = 0; i < Rpatients.Count; i++)
            {
                if (Rpatients[i].get_id() == textBox70.Text)
                {
                    comboBox8.Text = Rpatients[i].deparname;
                    textBox66.Text = Rpatients[i].get_name();
                    textBox69.Text = Rpatients[i].get_address();
                    textBox68.Text = Rpatients[i].get_age();
                    textBox65.Text = Rpatients[i].get_phonenumber();
                    inn = true;
                }
            }
            if (!inn)
            {
                MessageBox.Show("Patient doesnot exist");
            }
        }

        private void button42_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < Rpatients.Count; i++)
                if (Rpatients[i].get_id() == textBox70.Text)
                {
                    if (Convert.ToInt32(Rpatients[i].room) < 100)
                    {
                        for (int j = 0; j < STrooms.Count; j++)
                        {
                            for (int x = 0; x < STrooms[j].Patients.Count; x++)
                            {
                                if (STrooms[j].Patients[x].get_id() == textBox70.Text)
                                {
                                    STrooms[j].deletepatient(STrooms[j].Patients[x]);
                                }
                            }
                        }
                    }
                    if (Convert.ToInt32(Rpatients[i].room) >= 100 && (Convert.ToInt32(Rpatients[i].room) < 200))
                    {
                        for (int j = 0; j < Srooms.Count; j++)
                        {
                            for (int x = 0; x < Srooms[j].Patients.Count; x++)
                            {
                                if (Srooms[j].Patients[x].get_id() == textBox70.Text)
                                {
                                    Srooms[j].deletepatient(Srooms[j].Patients[x]);
                                }
                            }
                        }
                    }
                    if (Convert.ToInt32(Rpatients[i].room) >= 200 && (Convert.ToInt32(Rpatients[i].room) < 300))
                    {
                        for (int j = 0; j < Prooms.Count; j++)
                        {
                            for (int x = 0; x < Prooms[j].Patients.Count; x++)
                            {
                                if (Prooms[j].Patients[x].get_id() == textBox70.Text)
                                {
                                    Prooms[j].deletepatient(Prooms[j].Patients[x]);
                                }
                            }
                        }
                    }
                    for (int j = 0; j < nurses.Count; j++)
                    {
                        for (int x = 0; x < nurses[j].l_patients.Count; x++)
                        {
                            if (nurses[j].l_patients[x].get_id() == textBox70.Text)
                            {
                                nurses[j].deletepatient(nurses[j].l_patients[x]);
                            }
                        }
                    }

                    Rpatients.Remove(Rpatients[i]);
                    MessageBox.Show("patient deleted");
                    textBox70.Text = textBox66.Text = textBox69.Text = textBox68.Text = textBox65.Text = comboBox8.Text = "";

                }
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox78_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button84_Click(object sender, EventArgs e)
        {
          
            for (int i = 0; i < Apatients.Count; i++)
            {
                if (textBox76.Text == Apatients[i].get_id())
                {
                    for (int j = 0; j < doctors.Count; j++)
                    {
                        for (int x = 0; x < doctors[j].Appointments.Count; x++)
                        {
                            if (doctors[j].Appointments[x].Patient != null)
                            {
                                if (doctors[j].Appointments[x].Patient.get_id() == textBox76.Text)
                                {
                                    doctors[j].Appointments.Remove(doctors[j].Appointments[x]);
                                }
                            }
                        }

                    }
                    for (int j = 0; j < appointments.Count; j++)
                    {
                        if (appointments[j].Patient.get_id() == textBox76.Text)
                        {
                            appointments[j].Patient = null;
                            appointments.Remove(appointments[j]);
                        }
                    }
                    for (int j = 0; j < doctors.Count; j++)
                    {
                        for (int x = 0; x < doctors[j].Appatients.Count; x++)
                        {
                            if (doctors[j].Appatients[x].get_id() == textBox76.Text)
                            {
                                doctors[j].Appatients.Remove(doctors[j].Appatients[x]);
                                
                            }
                        }
                    }
                 
                    Apatients.Remove(Apatients[i]);
                    MessageBox.Show("patient has been deleted");
                    textBox76.Text = textBox73.Text = comboBox23.Text = textBox75.Text = textBox74.Text = textBox72.Text = "";
                }
            }
           
           
        }

        private void button34_Click(object sender, EventArgs e)
        {
            bool inn = false;
            if (textBox18.Text == "" || textBox19.Text == "" || textBox20.Text == "" || textBox21.Text == "" || textBox22.Text == "" || comboBox21.Text == "" || comboBox7.Text == "" || comboBox18.Text == "" || comboBox19.Text == "" || textBox67.Text == "")
            {
                MessageBox.Show("something wrong,please try again");

            }
            else
            {
                appointmentpatient b = new appointmentpatient();
                appointment a = new appointment();
                a.date = comboBox20.Text + "/" + comboBox17.Text + "/" + comboBox26.Text;
                a.Duration = Convert.ToDouble(comboBox18.Text) + Convert.ToDouble(comboBox19.Text);

                if (comboBox7.Text != "" && comboBox18.Text != "" && comboBox19.Text != "")
                {
                    for (int i = 0; i < doctors.Count; i++)
                    {
                        if (doctors[i].get_id() == comboBox7.Text)
                        {
                            doctors[i].isfree(a);
                            if (doctors[i].free == true)
                            {
                                inn = true;

                            }
                            else
                                MessageBox.Show("this appointment isnot free please chose another");
                            break;
                        }
                    }
                }
                if (inn)
                {

                    b.set_id(textBox22.Text);
                    b.set_name(textBox21.Text);
                    b.set_address(textBox20.Text);
                    b.set_age(textBox19.Text);
                    b.set_phonenumber(textBox18.Text);
                    b.medicaldiagonis = textBox29.Text;
                    b.deparname = comboBox21.Text;
                    b.appointment = a;
                    b.bill = textBox67.Text;
                    
                    for (int i = 0; i < departments.Count; i++)
                    {
                        if (departments[i].name == comboBox21.Text)
                        {
                            departments[i].addpatient(b);
                        }
                    }
                    a.addpatient(b);
                    b.appointment = a;
                    Apatients.Add(b);
                    appointments.Add(a);
                    for (int i = 0; i < doctors.Count; i++)
                    {
                        if (doctors[i].get_id() == comboBox7.Text)
                        {
                            a.adddoctor(doctors[i]);
                            doctors[i].addappointmentpatient(b);
                            doctors[i].addAppointment(a);
                            b.doc = doctors[i];

                        }
                    }
                    MessageBox.Show("patient Added");
                    AP_ID++;
                    textBox22.Text = Convert.ToString(AP_ID);
                    textBox18.Text = textBox19.Text = comboBox20.Text = comboBox17.Text = comboBox26.Text = textBox20.Text = textBox21.Text = textBox29.Text = comboBox21.Text = comboBox7.Text = comboBox18.Text = comboBox19.Text = textBox67.Text = "";
                    comboBox7.Items.Clear();

                }
            }
        }

        private void comboBox21_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.Items.Clear();
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].departmentname == comboBox21.Text)
                {

                    comboBox7.Items.Add(doctors[i].get_id());

                }
            }
        }

        private void comboBox26_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox22_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox9.Items.Clear();
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].departmentname == comboBox22.Text)
                {

                    comboBox9.Items.Add(doctors[i].get_id());

                }
            }
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button83_Click(object sender, EventArgs e)
        {
            bool inn = false;
            for (int i = 0; i < Apatients.Count; i++)
            {
                if (Apatients[i].get_id() == textBox76.Text)
                {
                    comboBox23.Text = Apatients[i].deparname;
                    textBox73.Text = Apatients[i].get_name();
                    textBox75.Text = Apatients[i].get_address();
                    textBox74.Text = Apatients[i].get_age();
                    textBox72.Text = Apatients[i].get_phonenumber();
         
                    inn = true;
                }
            }
            if (!inn)
            {
                MessageBox.Show("Patient doesnot exist");
                textBox76.Text = "";
            }
        }
    }
}
