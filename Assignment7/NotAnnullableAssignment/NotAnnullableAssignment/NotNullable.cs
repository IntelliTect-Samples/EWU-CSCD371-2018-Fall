namespace BrianBosAssignmentSeven
{
    /*
     * If T isn't a reference type (class constraint), then it is a value type, which is not nullable to begin with.
     * Therefore, creating a NotNullable containing a value type does not accomplish anything.
     * 
     * There is the flip side to this argument, however.
     * If value types are already not nullable, why are they not allowed?
     * 
     * This is a problem in API design -
     * do we add a feature that offers convenience/utility at the expense of allowing developers to do unnecessary/harmful things,
     * or do we not add the feature, stopping developers from doing unnecessary/harmful things at the expense of a potential for convenience/utility?
     * 
     * In this case, developers are prevented from storing value types inside NotNullable.
     * This prevents redundant computations (storing, conditional logic, etc.),
     * at the cost of losing the convenience of having all not-nullable types under the same abstraction (that is, the NotNullable class.)
     * 
     * Allowing value types would also significantly increase the conditional complexity of NotNullable,
     * requiring that the interopability of value and reference types would have to be extensively tested.
     * 
     * 
     * T must also support creation with a default (empty) constructor.
     * 
     * This is another limitation of the NotNullable implementation.
     * If a type doesn't support using a default constructor, then it cannot be used in NotNullable.
     * 
     * In order to not be null, reference types must be instantiated somehow (as their default value is null.)
     * My current experience (which may be wrong) tells me that many types will support instantiation through public default constructors,
     * but fewer types will support instantiation through any other singular means (such as a variant of factory.)
     * 
     * There is no point in forcing it to support multiple mechanisms of instantiation simultaneously,
     * and there is also no way to OR the constraints.
     * 
     * For these reasons, default constructor instantiation seemed like the best constraint choice to me.
     * 
     * 
     * If the Value setter is passed a null, then it will ignore the null and leave _Value unchanged.
     * This behavior was chosen because it was the simplest option.
     * 
     * Since T is a reference type, there is no way to enforce compile-time null restrictions.
     * Constraining T to be a struct would enforce compile-time null restrictions, but would also make NotNullable redundant (as explained earlier.)
     * 
     * There are multiple different factors to consider when choosing how to deal with an attempt to set Value to null.
     * 
     * The first factor is choosing what to do with Value.
     * One option (the one currently implemented) ignore the request and leave Value unchanged.
     * Another option is to reset Value to its default state by creating a new instance.
     * 
     * The second factor is choosing whether or not to throw an exception.
     * The current implementation does not throw an exception.
     * 
     * Each factor choice has valid use cases, with the best choice being application-dependent.
     * The most important thing, regardless of choice, is to document the behavior.
     */
    public class NotNullable<T>
        where T : class, new()
    {
        private T _Value;
        public T Value
        {
            get
            {
                return _Value;
            }

            set
            {
                if (value != null)
                {
                    _Value = value;
                }
            }
        }

        public NotNullable()
        {
            /*
             * As far as I know, there is no way for a constructor to return null.
             * 
             * If an exception is thrown in the default constructor for T, _Value will be null because it was unassigned.
             * However, that same exception will also be left unhandled by this constructor, causing it to abort construction
             * of the forbidden null-Value NotNullable.
             */
            _Value = new T();
        }
    }
}