using System;
using System.Runtime.Serialization;

namespace OOP_complexe
{
    [Serializable]
    internal class DenominatorIsZero : Exception
    {
        private int partea_reala;

        public DenominatorIsZero()
        {
        }

        public DenominatorIsZero(int partea_reala)
        {
            this.partea_reala = partea_reala;
        }

        public DenominatorIsZero(string message) : base(message)
        {
        }

        public DenominatorIsZero(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DenominatorIsZero(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}