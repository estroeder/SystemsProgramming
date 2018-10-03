using System;

namespace Assignment1
{
    internal class Symbol : IComparable<Symbol>
    {
        public string Label;
        public int Value;
        public bool Rflag, IFlag, Mflag, IsValid;

        public Symbol()
        {
            IsValid = false;
        }

        public Symbol(string label, int value, bool rflag, bool iflag = true, bool mflag = false)
        {
            Label = label;
            Value = value;
            Rflag = rflag;
            IFlag = iflag;
            Mflag = mflag;
            IsValid = true;
        }

        #region ComparableMethods

        public int CompareTo(Symbol nodeToCompare)
        {
            return (string.Compare(this.Label, nodeToCompare.Label, StringComparison.Ordinal));
        }

        #endregion ComparableMethods
    }
}
