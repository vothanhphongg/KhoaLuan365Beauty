﻿using _365Beauty.Contract.Shared;

namespace _365Beauty.Contract.Validators
{
    /// <summary>
    /// Builder to build up validation rules for property
    /// </summary>
    /// <typeparam name="TProperty">Property type</typeparam>
    public class RuleBuilder<TProperty>
    {
        /// <summary>
        /// Instance of validator, use to add rule to validator
        /// </summary>
        private readonly IValidator validator;

        /// <summary>
        /// Property to validate
        /// </summary>
        public TProperty Property { get; }

        /// <summary>
        /// Name of property
        /// </summary>
        public string PropertyName { get; }

        public RuleBuilder(IValidator validator, TProperty property, string propertyName)
        {
            this.validator = validator;
            Property = property;
            PropertyName = propertyName;
        }

        /// <summary>
        /// Create rule that this property must not null or equal default value
        /// </summary>
        /// <param name="message">Message attached. If not, will use default message</param>
        /// <returns></returns>
        public RuleBuilder<TProperty> NotNull(string? message = null)
        {
            bool Func(TProperty b) => Property is not null && !Property.Equals(default);
            var msgArgs = new List<MessageArgs> { new(Args.PROPERTY_NAME, PropertyName) };
            message = message ?? MessConst.NOT_NULL.FillArgs(msgArgs);
            var rule = new Rule<TProperty>(Func, Property, message);
            validator.AddRule(rule);
            return this;
        }

        /// <summary>
        /// Create rule that this property must match a specific predicate
        /// </summary>
        /// <param name="condition">Condition to check for this property, must have property as param and return bool value</param>
        /// <param name="message">Message attached. If not, will use default message</param>
        /// <returns></returns>
        public RuleBuilder<TProperty> Must(Func<TProperty, bool> condition, string? message = null)
        {
            var msgArgs = new List<MessageArgs> { new(Args.PROPERTY_NAME, PropertyName) };
            message = message ?? MessConst.NOT_MATCH_CONDITION.FillArgs(msgArgs);
            var rule = new Rule<TProperty>(condition, Property, message);
            validator.AddRule(rule);
            return this;
        }

        /// <summary>
        /// Add new rule to validator
        /// </summary>
        /// <param name="rule"></param>
        public void AddRule(IRule rule)
        {
            validator.AddRule(rule);
        }
    }
}
