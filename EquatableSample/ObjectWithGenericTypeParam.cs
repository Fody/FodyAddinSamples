using System;

using Equatable;

namespace Base
{
    using Xunit;

    using Target = ObjectWithGenericTypeParam<string, ObjectWithValueTypeMembers>;

    [ImplementsEquatable]
    public class ObjectWithGenericTypeParam<T1, T2>
    {
        [Equals]
        public string _field;

        [Equals]
        public Tuple<int, T1> Property1 { get; set; }

        [Equals]
        public Tuple<int, T2> Property2 { get; set; }
    }

    public class ObjectWithGenericTypeParamTests
    {
        [Fact]
        public void ImplementsIEquatable()
        {
            var target = new Target();

            Assert.True(target is IEquatable<Target>);
        }

        [Fact]
        public void AreEqualWhenAllPropertiesAreEqual()
        {
            var left = new Target
            {
                _field = "test",
                Property1 = new Tuple<int, string>(5, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 3 }),
            };

            var right = new Target
            {
                _field = "test",
                Property1 = new Tuple<int, string>(5, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 3 }),
            };

            Assert.Equal(left, right);
            Assert.Equal(left.GetHashCode(), right.GetHashCode());
        }

        [Fact]
        public void AreDifferentWhenOneAttributedPropertyIsDifferent()
        {
            var left = new Target
            {
                _field = "test",
                Property1 = new Tuple<int, string>(5, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 3 }),
            };

            var right = new Target
            {
                _field = "test",
                Property1 = new Tuple<int, string>(5, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 4 }),
            };

            Assert.NotEqual(left, right);
            Assert.NotEqual(left.GetHashCode(), right.GetHashCode());
        }

        [Fact]
        public void AreDifferentWhenAllAttributedPropertiesAreDifferent()
        {
            var left = new Target
            {
                _field = "test",
                Property1 = new Tuple<int, string>(5, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 3 }),
            };

            var right = new Target
            {
                _field = "test",
                Property1 = new Tuple<int, string>(6, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 4 }),
            };

            Assert.NotEqual(left, right);
            Assert.NotEqual(left.GetHashCode(), right.GetHashCode());
        }

        [Fact]
        public void AreDifferentWhenTheFieldIsDifferent()
        {
            var left = new Target
            {
                _field = "test",
                Property1 = new Tuple<int, string>(5, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 3 }),
            };

            var right = new Target
            {
                _field = "test1",
                Property1 = new Tuple<int, string>(5, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 3 }),
            };

            Assert.NotEqual(left, right);
            Assert.NotEqual(left.GetHashCode(), right.GetHashCode());
        }
    }
}

namespace Derived
{
    using Base;

    using Xunit;

    using Target = DerivedObjectWithGenericParam<ObjectWithValueTypeMembers>;

    [ImplementsEquatable]
    public class DerivedObjectWithGenericParam<T3>
        : ObjectWithGenericTypeParam<string, T3>
    {
        [Equals]
        public string Property3 { get; set; }
    }

    public class DerivedObjectWithGenericTypeParamTests
    {

        [Fact]
        public void ImplementsIEquatable()
        {
            var target = new Target();

            Assert.True(target is IEquatable<Target>);
        }

        [Fact]
        public void AreEqualWhenAllPropertiesAreEqual()
        {
            var left = new Target
            {
                _field = "test",
                Property1 = new Tuple<int, string>(5, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 3 }),
                Property3 = "x"
            };

            var right = new Target
            {
                _field = "test",
                Property1 = new Tuple<int, string>(5, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 3 }),
                Property3 = "x"
            };

            Assert.Equal(left, right);
            Assert.Equal(left.GetHashCode(), right.GetHashCode());
        }

        [Fact]
        public void AreDifferentWhenTheDerivedPropertyIsDifferent()
        {
            var left = new Target
            {
                _field = "test",
                Property1 = new Tuple<int, string>(5, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 3 }),
                Property3 = "x"
            };

            var right = new Target
            {
                _field = "test",
                Property1 = new Tuple<int, string>(5, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 3 }),
                Property3 = "y"
            };

            Assert.NotEqual(left, right);
            Assert.NotEqual(left.GetHashCode(), right.GetHashCode());
        }

        [Fact]
        public void AreDifferentWhenOneBaseAttributedPropertyIsDifferent()
        {
            var left = new Target
            {
                _field = "test",
                Property1 = new Tuple<int, string>(5, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 3 }),
                Property3 = "x"
            };

            var right = new Target
            {
                _field = "test",
                Property1 = new Tuple<int, string>(5, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 4 }),
                Property3 = "x"
            };

            Assert.NotEqual(left, right);
            Assert.NotEqual(left.GetHashCode(), right.GetHashCode());
        }

        [Fact]
        public void AreDifferentWhenAllBaseAttributedPropertiesAreDifferent()
        {
            var left = new Target
            {
                _field = "test",
                Property1 = new Tuple<int, string>(5, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 3 }),
                Property3 = "x"
            };

            var right = new Target
            {
                _field = "test",
                Property1 = new Tuple<int, string>(6, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 4 }),
                Property3 = "x"
            };

            Assert.NotEqual(left, right);
            Assert.NotEqual(left.GetHashCode(), right.GetHashCode());
        }

        [Fact]
        public void AreDifferentWhenTheBaseFieldIsDifferent()
        {
            var left = new Target
            {
                _field = "test",
                Property1 = new Tuple<int, string>(5, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 3 }),
                Property3 = "x"
            };

            var right = new Target
            {
                _field = "test1",
                Property1 = new Tuple<int, string>(5, "test"),
                Property2 = new Tuple<int, ObjectWithValueTypeMembers>(2, new ObjectWithValueTypeMembers { Property1 = 3 }),
                Property3 = "x"
            };

            Assert.NotEqual(left, right);
            Assert.NotEqual(left.GetHashCode(), right.GetHashCode());
        }
    }
}

