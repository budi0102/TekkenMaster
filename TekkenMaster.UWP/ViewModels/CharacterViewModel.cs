using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekkenLibrary.Model;

namespace TekkenMaster.UWP.ViewModels
{
    public class CharacterViewModel : ViewModelBase
    {
        #region Public Properties
        public string Name { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Introduction { get; set; }
        public string Description { get; set; }
        public MoveListViewModel BasicMoveList { get; set; }
        public MoveListViewModel SpecialMoveList { get; set; }
        public MoveListViewModel TenHitMoveList { get; set; }
        public MoveListViewModel ThrowMoveList { get; set; }
        public MoveListViewModel ComboList { get; set; }

        public string Image { get; set; }
        #endregion

        #region Constructor
        public CharacterViewModel()
        {
        }

        public CharacterViewModel(
            string name,
            string fullName,
            string shortName,
            string introduction,
            string description,
            MoveListViewModel basicMoveList,
            MoveListViewModel specialMoveList,
            MoveListViewModel tenHitMoveList,
            MoveListViewModel throwMoveList,
            MoveListViewModel comboList)
        {
            this.Name = name;
            this.FullName = fullName;
            this.ShortName = shortName;
            this.Introduction = introduction;
            this.Description = description;
            this.BasicMoveList = basicMoveList;
            this.SpecialMoveList = specialMoveList;
            this.TenHitMoveList = tenHitMoveList;
            this.ThrowMoveList = throwMoveList;
            this.ComboList = comboList;
        }

        public CharacterViewModel(TekkenLibrary.Model.Character character)
            : this(
                  character.Name,
                  character.FullName,
                  character.ShortName,
                  character.Introduction,
                  character.Description,
                  new MoveListViewModel(character.BasicMoveList),
                  new MoveListViewModel(character.SpecialMoveList),
                  new MoveListViewModel(character.TenHitMoveList),
                  new MoveListViewModel(character.ThrowMoveList),
                  new MoveListViewModel(character.ComboList))
        {
        }
        #endregion
    }
}
