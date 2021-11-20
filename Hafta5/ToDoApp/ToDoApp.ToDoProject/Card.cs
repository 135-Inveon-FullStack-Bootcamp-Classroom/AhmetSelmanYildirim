using System;
using System.Collections.Generic;

namespace ToDoApp.ToDoProject
{
    public class Card
    {
        public Card(string title, string description, Member member, Size size, Line line)
        {
            this.Title = title;
            this.Description = description;
            this.Member = member;
            this.Size = size;
            this.Line = line;

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Member Member { get; set; }
        public Size Size { get; set; }
        public Line Line { get; set; }


    }
    
    
}
