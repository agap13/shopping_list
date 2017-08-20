package md51a06f482dd33caeddd718ef915aa6720;


public class FormsApplicationActivity
	extends md5071d1f4a49a745d7b3d3598c8427e970.MvxFormsApplicationActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Shopping.Droid.FormsApplicationActivity, Shopping.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", FormsApplicationActivity.class, __md_methods);
	}


	public FormsApplicationActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == FormsApplicationActivity.class)
			mono.android.TypeManager.Activate ("Shopping.Droid.FormsApplicationActivity, Shopping.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
