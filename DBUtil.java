package com.bottle.stockmanage;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import android.os.Handler;
import android.os.Message;

public class DBUtil 
{
	private ArrayList<String> arrayList1 = new ArrayList<String>();
	private ArrayList<String> arrayList2 = new ArrayList<String>();
	private ArrayList<String> arrayList3 = new ArrayList<String>();
	
	private HttpConnSoap Soap = new HttpConnSoap();

	public List<HashMap<String, String>> getAllInfo(final Handler myhandler) 
	{
		HashMap<String, String> tempHash = new HashMap<String, String>();
		List<HashMap<String, String>> list = new ArrayList<HashMap<String, String>>();
		tempHash.put("Cno", "Cno");
		tempHash.put("Cname", "Cname");
		tempHash.put("Cnum", "Cnum");
		list.clear();
		arrayList1.clear();
		arrayList2.clear();
		arrayList3.clear();
		list.add(tempHash);

		new Thread()
		{
			public void run()
			{
				arrayList1 = Soap.GetWebServer("selectAllCargoInfor", arrayList1, arrayList2);
				Message msg=new Message();
				msg.what=0x123;
				msg.obj=arrayList1;
				myhandler.sendMessage(msg);
			}
		}.start();
	
		return list;
	}

	public void insertCargoInfo(String Cname, String Cnum) 
	{
		arrayList1.clear();
		arrayList2.clear();
		arrayList1.add("Cname");
		arrayList1.add("Cnum");
		arrayList2.add(Cname);
		arrayList2.add(Cnum);
		
		new Thread()
		{
			public void run()
			{
				try
				{
					Soap.GetWebServer("insertCargoInfo", arrayList1, arrayList2);
				}
				catch(Exception e)
				{
					
				}
			}
		}.start();
	}

	public void deleteCargoInfo(String Cno) 
	{
		arrayList1.clear();
		arrayList2.clear();
		arrayList1.add("Cno");
		arrayList2.add(Cno);
		
		new Thread()
		{
			public void run()
			{
				try
				{
					Soap.GetWebServer("deleteCargoInfo", arrayList1, arrayList2);
				}
				catch(Exception e)
				{
				
				}
			}
		}.start();
	}
	
}
