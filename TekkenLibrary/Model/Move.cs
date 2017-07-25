using System;
using System.Collections.Generic;
using System.Text;

namespace TekkenLibrary.Model
{
    public class Move
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameJp { get; set; }
        public string Notation { get; set; }
        public string NotationJp { get; set; }
        public string HitPosition { get; set; }
        public string HitPositionJp { get; set; }
        public string Damage { get; set; }
        public string ActiveFrame { get; set; }
        public string Guard { get; set; }
        public string Hit { get; set; }
        public string Counter { get; set; }
        public string Note { get; set; }
        public string ThrowEscapeNotation { get; set; }
        public string AfterThrowEscape { get; set; }
        public string AfterThrowStatus { get; set; }

        public Move()
        {
        }
    }
}
