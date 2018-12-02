using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyDisposable.Tests
{
	[TestClass]
	public class MyDisposableTests
	{
		[TestMethod]
		public void MyDisposable_Create_Success()
		{
			MyDisposable md = new MyDisposable("success");
			Assert.IsNotNull(md);
			Assert.AreEqual(1, MyDisposable.Instances);
			Assert.AreEqual("There are 1 instances of MyDisposable! This MyDisposable has the name success.", md.ToString());
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MyDisposable_Create_ArgumentNullException()
		{
			MyDisposable md = new MyDisposable(null);
		}

		[TestMethod]
		public void MyDisposable_CreateMultiple_Success()
		{
			MyDisposable.Instances = 0;
			MyDisposable md1 = new MyDisposable("1");
			MyDisposable md2 = new MyDisposable("2");
			MyDisposable md3 = new MyDisposable("3");
			Assert.AreEqual(3, MyDisposable.Instances);
		}

		[TestMethod]
		public void MyDisposable_Dispose_Success()
		{
			MyDisposable.Instances = 0;
			MyDisposable md1 = new MyDisposable("1");
			MyDisposable md2 = new MyDisposable("2");
			MyDisposable md3 = new MyDisposable("3");
			md1.Dispose();
			md2.Dispose();
			Assert.AreEqual(1, MyDisposable.Instances);
		}

		[TestMethod]
		public void MyDisposable_Using_Success()
		{
			MyDisposable.Instances = 0;
			using (MyDisposable md = new MyDisposable("disposable"))
			{
				Assert.AreEqual(1, MyDisposable.Instances);
			}
			Assert.AreEqual(0, MyDisposable.Instances);
		}

		[TestMethod]
		[ExpectedException(typeof(ObjectDisposedException))]
		public void MyDisposable_ToStringAfterDispose_ThrowsObjectDisposedException()
		{
			MyDisposable md = new MyDisposable("disposable");
			md.Dispose();
			md.ToString();
		}

		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void MyDisposable_NameSetToNullAfterDispose_ThrowsNullReferenceException()
		{
			MyDisposable md = new MyDisposable("name");
			md.Dispose();
			int len = md.Name.Length;
		}
	}
}
