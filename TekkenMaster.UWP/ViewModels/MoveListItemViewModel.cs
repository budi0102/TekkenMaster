using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Mvvm;

namespace TekkenMaster.UWP.ViewModels
{
    public class MoveListItemViewModel : ViewModelBase
    {
        #region Public Properties
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
        #endregion

        #region Constructor
        public MoveListItemViewModel()
            : this(-1,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
        {
        }

        public MoveListItemViewModel(
            int id,
            string name,
            string nameJp,
            string notation,
            string notationJp,
            string hitPosition,
            string hitPositionJp,
            string damage,
            string activeFrame,
            string guard,
            string hit,
            string counter,
            string note,
            string throwEscapeNotation,
            string afterThrowEscape,
            string afterThrowStatus)
        {
            this.ID = id;
            this.Name = name;
            this.NameJp = nameJp;
            this.Notation = notation;
            this.NotationJp = notationJp;
            this.HitPosition = hitPosition;
            this.HitPositionJp = hitPositionJp;
            this.Damage = damage;
            this.ActiveFrame = activeFrame;
            this.Guard = guard;
            this.Hit = hit;
            this.Counter = counter;
            this.Note = note;
            this.ThrowEscapeNotation = throwEscapeNotation;
            this.AfterThrowEscape = afterThrowEscape;
            this.AfterThrowStatus = afterThrowStatus;
        }

        public MoveListItemViewModel(TekkenLibrary.Model.Move move)
            : this(
                  move.ID,
                  move.Name,
                  move.NameJp,
                  move.Notation,
                  move.NotationJp,
                  move.HitPosition,
                  move.HitPositionJp,
                  move.Damage,
                  move.ActiveFrame,
                  move.Guard,
                  move.Hit,
                  move.Counter,
                  move.Note,
                  move.ThrowEscapeNotation,
                  move.AfterThrowEscape,
                  move.AfterThrowStatus)
        {
        }
        #endregion
    }
}
