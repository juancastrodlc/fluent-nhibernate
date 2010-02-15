using System;
using System.Diagnostics;
using FluentNHibernate.MappingModel.Identity;

namespace FluentNHibernate.Mapping
{
    public class KeyManyToOnePart
    {
        private readonly KeyManyToOneMapping mapping;
        private bool nextBool = true;
        private readonly AccessStrategyBuilder access;

        public KeyManyToOnePart(KeyManyToOneMapping mapping)
        {
            this.mapping = mapping;
            access = new AccessStrategyBuilder(value => mapping.Access = value);
            NotFound = new NotFoundExpression<KeyManyToOnePart>(this, value => mapping.NotFound = value);
        }

        /// <summary>
        /// Inverts the next boolean
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public KeyManyToOnePart Not
        {
            get
            {
                nextBool = !nextBool;
                return this;
            }
        }

        public KeyManyToOnePart ForeignKey(string foreignKey)
        {
            mapping.ForeignKey = foreignKey;
            return this;
        }

        /// <summary>
        /// Defines how NHibernate will access the object for persisting/hydrating (Defaults to Property)
        /// </summary>
        public AccessStrategyBuilder<KeyManyToOnePart> Access
        {
            get { return new AccessStrategyBuilder<KeyManyToOnePart>(this, access); }
        }

        public NotFoundExpression<KeyManyToOnePart> NotFound { get; private set; }

        public KeyManyToOnePart Lazy()
        {
            mapping.Lazy = nextBool;
            nextBool = true;
            return this;
        }

        public KeyManyToOnePart Name(string name)
        {
            mapping.Name = name;
            return this;
        }

        
    }
}