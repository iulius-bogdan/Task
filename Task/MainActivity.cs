using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using PerpetualEngine.Storage;
using Task.Resources;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Task
{
    [Activity(Label = "Task", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        string Materie;
        string Ora;
        string Zi;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SimpleStorage.EditGroup = (string groupName) =>
            {
                return new DroidSimpleStorage(groupName, this);
            };

            SetContentView(Resource.Layout.Main);

            var spinnerZi = FindViewById<Spinner>(Resource.Id.spinner);
            string firstItemZi = spinnerZi.SelectedItem.ToString();
            spinnerZi.ItemSelected += (s, e) =>
            {

                Zi = spinnerZi.SelectedItem.ToString();

            };
            var spinnerMaterie = FindViewById<Spinner>(Resource.Id.spinner1);
            string firstItemMaterie = spinnerMaterie.SelectedItem.ToString();
            spinnerMaterie.ItemSelected += (s, e) =>
            {

                Materie = spinnerMaterie.SelectedItem.ToString();

            };

            var spinnerOra = FindViewById<Spinner>(Resource.Id.spinner2);
            string firstItemOra = spinnerOra.SelectedItem.ToString();
            spinnerOra.ItemSelected += (s, e) =>
            {

                Ora = spinnerOra.SelectedItem.ToString();
            };



            Button Mybutton1 = FindViewById<Button>(Resource.Id.button1);
            Mybutton1.Click += Mybutton1_Click;



            Button Mybutton = FindViewById<Button>(Resource.Id.button);
            Mybutton.Click += Mybutton_Click;

            Button Mybutton2 = FindViewById<Button>(Resource.Id.button2);
            Mybutton2.Click += Mybutton2_Click;

            Button Mybutton3 = FindViewById<Button>(Resource.Id.button3);
            Mybutton3.Click += Mybutton3_Click;
        }



            private void Mybutton2_Click(object sender, System.EventArgs e)
        {
            var Obj = new Data2();
            Obj.Ora = Ora;
            Obj.Materie = Materie;



            var storage = SimpleStorage.EditGroup("DB");

            var List = storage.Get(Zi);
            if (List != null  && List != "")
            {
                var ObjectList = JsonConvert.DeserializeObject<List<Data2>>(List);

                ObjectList.Add(Obj);

                var SerieList = JsonConvert.SerializeObject(ObjectList);
                storage.Put(Zi, SerieList);

            }

            else
            {
                var ObjectList = new List<Data2>();
                ObjectList.Add(Obj);
                var SerieList = JsonConvert.SerializeObject(ObjectList);
                storage.Put(Zi, SerieList);

            }
        }

        private void Mybutton3_Click(object sender, System.EventArgs e)
        {

            var storage = SimpleStorage.EditGroup("DB");
            storage.Put("Monday", "");


        }
       
        private void Mybutton1_Click(object sender, System.EventArgs e)
        {
            var activity2 = new Intent(this, typeof(About));
            activity2.PutExtra("MyData", "Data from Activity1");
            StartActivity(activity2);
        }

        private void Mybutton_Click(object sender, System.EventArgs e)
        {
            var activity2 = new Intent(this, typeof(AfisareOrar));
            activity2.PutExtra("Ziua", Zi);

            StartActivity(activity2);


         
        }
    }
}

