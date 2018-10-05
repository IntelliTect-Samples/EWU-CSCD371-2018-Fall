using System;

public class Stack
{  
   private class Node
   {
      private Node next;
      private String data;
      public Node(Node next, String data)
      {
         this.next = next;
         this.data = data;
      }
      public Node getNext()
      {
          return this.next;
      }

      public String getData()
      {
          return this.data;
      }
   }
   private Node top;
   public Stack()
   {
      this.top = null;
   }
   public bool isEmpty()
   {
      return this.top == null;
   }
   public void push(String data)
   {
      if(String.IsNullOrEmpty(data))
      {
         Console.WriteLine("Cannot add null value");
      }
      else
      {
         this.top = new Node(this.top, data);
      }
   }
   public String peek()
   {
      if(isEmpty())
      {
         throw new InvalidOperationException("Cannot peek from a empty Stack.");
      }
      else
      {
         return this.top.getData();
      }
   }
   public String pop()
   {
      if(isEmpty())
      {
         return "No Expression";
      }
      else
      {
         String tempData = this.top.getData();
         this.top = this.top.getNext();
         return tempData;
      }
   }
}