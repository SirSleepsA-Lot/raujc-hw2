using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using zad2;
/// <summary>
/// Nisam radio dva testa tj. nisam testirao TodoIteme jer ih koristim u ovim testovima,
/// a oni ne bi bili dobri da mi nesto nije u redu sa TodoItem klasom
/// </summary>
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddTORepositorty()
        {
            TodoRepository rep = new TodoRepository();
            TodoItem item1 = new TodoItem("Test1");
            TodoItem item2 = new TodoItem("Test2");
            rep.Add(item1);
            Assert.AreEqual(item1, rep.Get(item1.Id));
            rep.Add(item2);
            Assert.AreEqual(item2, rep.Get(item2.Id));
            Assert.AreEqual(item1, rep.Get(item1.Id));
            Assert.AreEqual(2, rep.Count());
        }
        [TestMethod]
        public void RemoveFromRepository()
        {
            TodoRepository rep = new TodoRepository();
            TodoItem item1 = new TodoItem("Test1");
            TodoItem item2 = new TodoItem("Test2");
            TodoItem item3 = new TodoItem("Test3");
            rep.Add(item2);
            rep.Add(item1);

            Assert.AreEqual(false, rep.Remove(item3.Id));
            Assert.AreEqual(2, rep.Count());
            Assert.AreEqual(true, rep.Remove(item2.Id));
        }
        [TestMethod]
        public void Completed()
        {
            TodoRepository rep = new TodoRepository();
            TodoItem item1 = new TodoItem("Test1");
            TodoItem item2 = new TodoItem("Test2");
            item1.DateCompleted = null;
            item2.DateCompleted = null;
            rep.Add(item2);
            rep.Add(item1);
            rep.MarkAsCompleted(item2.Id);
            Assert.AreEqual(1, rep.GetCompleted().Count);
            Assert.AreEqual(1, rep.GetActive().Count);
        }
        [TestMethod]
        public void GetAll()
        {
            TodoRepository rep = new TodoRepository();
            TodoItem item1 = new TodoItem("Test1");
            Thread.Sleep(1000);
            TodoItem item2 = new TodoItem("Test2");
            rep.Add(item2);
            rep.Add(item1);
            //s obzirom da je item2 prvi dodan on ce biti na nultom indexu u DB, ali na prvom u listi
            Assert.AreEqual(item1, rep.GetAll().ToArray()[0]);
        }
        [TestMethod]
        public void GetCompleted_Active()
        {
            TodoRepository rep = new TodoRepository();
            TodoItem item1 = new TodoItem("Test1");
            TodoItem item2 = new TodoItem("Test2");
            TodoItem item3 = new TodoItem("Test3");
            item1.DateCompleted = null;
            item2.DateCompleted = null;
            item3.DateCompleted = null;
            rep.Add(item1);
            rep.Add(item2);
            rep.Add(item3);
            rep.MarkAsCompleted(item2.Id);
            Assert.AreEqual(2, rep.GetActive().Count);
            Assert.AreEqual(1, rep.GetCompleted().Count);
            rep.MarkAsCompleted(item3.Id);
            Assert.AreEqual(1, rep.GetActive().Count);
            Assert.AreEqual(2, rep.GetCompleted().Count);
        }
        [TestMethod]
        public void GetFiltered()
        {
            TodoRepository rep = new TodoRepository();
            TodoItem item1 = new TodoItem("Test1");
            TodoItem item2 = new TodoItem("Test2");
            TodoItem item3 = new TodoItem("Test2");
            TodoItem item4 = new TodoItem("Test2");
            rep.Add(item1);
            rep.Add(item2);
            rep.Add(item3);
            rep.Add(item4);
            Assert.AreEqual(4, rep.GetAll().Count);
            Assert.AreEqual(item1, rep.GetFiltered(i => i.Text == "Test1").ToArray()[0]);
            Assert.AreEqual(1, rep.GetFiltered(i => i.Text == "Test1").Count);

        }
        [TestMethod]
        public void MarkCompleted()
        {
            TodoItem item = new TodoItem("Test1");
            Assert.AreEqual("Test1", item.Text);
            Assert.AreEqual(true, item.DateCompleted == null);

        }
    }
}
