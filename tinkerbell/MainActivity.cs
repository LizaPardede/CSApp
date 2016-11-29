using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Data;

namespace tinkerbell
{
    [Activity(Label = "tinkerbell", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private List<string> mItems;
        private ListView mListView;

       
       

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);
            mListView = FindViewById<ListView>(Resource.Id.listView1);

            MyWebService.WebService1 myService = new MyWebService.WebService1();
            myService.Url = "http://10.160.1.123/AndroidService/WebService1.asmx";

            mItems = new List<string>();
            DataSet ds = myService.GetDataPoly();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++) {
               
                mItems.Add(ds.Tables[0].Rows[i]["Poly_ID"].ToString() + "-" + ds.Tables[0].Rows[i]["Poly_Name"].ToString() + "-" + ds.Tables[0].Rows[i]["Poly_InvLoc_ID"].ToString() + "-" + ds.Tables[0].Rows[i]["Poly_Active"].ToString() + "-" + ds.Tables[0].Rows[i]["Insert_User"].ToString() + "-" + ds.Tables[0].Rows[i]["Insert_Date"].ToString() + "-" + ds.Tables[0].Rows[i]["Update_User"].ToString() + "-" + ds.Tables[0].Rows[i]["Update_Date"].ToString());
                
            }
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mItems);
            mListView.Adapter = adapter;

        }
    }
}

