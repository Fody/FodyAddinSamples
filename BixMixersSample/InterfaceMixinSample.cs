using BixMixersMixinDefinitions;
using BixMixersMixinTargets;
using NUnit.Framework;
using System;

namespace BixMixersSample
{
    [TestFixture(Category = "Bix.Mixers")]
    public class InterfaceMixinSample
    {
        [Test]
        public void MixinWorksAsExpected()
        {
            var target = new MixinTarget();
            var targetAsInterface = target as IMixinDefinition;

            // show that the interface is implemented
            Assert.That(target, Is.InstanceOf<IMixinDefinition>());

            // show that the existing property was untouched
            Assert.That(target.NonMixinProperty == 5);

            // show that the mixin property and field are available, including the explicitly implemented property
            Assert.That(target.Field, Is.EqualTo(0));
            Assert.That(target.Property, Is.EqualTo(int.MinValue));
            Assert.That(targetAsInterface.Property, Is.EqualTo(0));
            target.Field = 3209;
            Assert.That(target.Field, Is.EqualTo(3209));
            Assert.That(target.Property, Is.EqualTo(int.MinValue));
            Assert.That(targetAsInterface.Property, Is.EqualTo(3209));

            // show that a generic method call works
            var expectedValue = string.Format("Input has type {0} and string converted value 42", typeof(int).FullName);
            Assert.That(target.GenericMethod(42), Is.EqualTo(expectedValue));
            expectedValue = string.Format("Input has type {0} and string converted value 42", typeof(long).FullName);
            Assert.That(target.GenericMethod(42L), Is.EqualTo(expectedValue));
            expectedValue = string.Format("Input has type {0} and string converted value forty-two", typeof(string).FullName);
            Assert.That(target.GenericMethod("forty-two"), Is.EqualTo(expectedValue));

            // show that the event calls delegate as expected and that the method is called correctly
            var callCount = 0;
            EventHandler<UnhandledExceptionEventArgs> eventHandler = (sender, e) =>
                {
                    Assert.That(sender, Is.InstanceOf<MixinTarget>());
                    Assert.That(e.ExceptionObject, Has.Message.EqualTo("Funny"));
                    ++callCount;
                };

            target.AFunnyThingHappened += eventHandler;
            var list = target.Method(23, "one", "two", "three");
            Assert.That(callCount, Is.EqualTo(1));
            Assert.That(list, Is.EquivalentTo(new string[] { "23", "one", "two", "three" }));

            target.AFunnyThingHappened -= eventHandler;
            list = target.Method(32);
            Assert.That(callCount, Is.EqualTo(1));
            Assert.That(list, Is.EquivalentTo(new string[] { "32" }));

            // show that the delegate type and property are accessible and that a lambda expression was handled
            Assert.That(typeof(MixinTarget.SomeDelegateType).DeclaringType, Is.EqualTo(typeof(MixinTarget)));
            Assert.That(target.SomeDelegate("Lambda will return me"), Is.EqualTo("Lambda will return me"));

            // show that the flags enum acts as expected (including check for custom attribute)
            Assert.That(typeof(MixinTarget.Attributes).DeclaringType, Is.EqualTo(typeof(MixinTarget)));
            Assert.That(Attribute.IsDefined(typeof(MixinTarget.Attributes), typeof(FlagsAttribute)));
            var things = MixinTarget.Attributes.Thing2 | MixinTarget.Attributes.Thing5;
            Assert.That(things, Is.EqualTo((MixinTarget.Attributes)18));

            // show that the nested struct acts as expected
            Assert.That(typeof(MixinTarget.NestedStruct).DeclaringType, Is.EqualTo(typeof(MixinTarget)));
            Assert.That(typeof(MixinTarget.NestedStruct).IsValueType);
            var nestedStruct = new MixinTarget.NestedStruct();
            nestedStruct.Value = 60;
            Assert.That(nestedStruct.Value, Is.EqualTo(60));

            // show that the nested class acts as expected
            Assert.That(typeof(MixinTarget.NestedEventArgs).DeclaringType, Is.EqualTo(typeof(MixinTarget)));
            Assert.That(typeof(MixinTarget.NestedEventArgs).BaseType, Is.EqualTo(typeof(EventArgs)));
            var nestedEventArgs = new MixinTarget.NestedEventArgs();
            Assert.That(nestedEventArgs.Things, Is.EqualTo(MixinTarget.Attributes.Nothing));

            // show that the static field acts as expected
            MixinTarget.StaticField = 0;
            Assert.That(MixinTarget.StaticField, Is.EqualTo(0));
            MixinTarget.StaticField = 9;
            Assert.That(MixinTarget.StaticField, Is.EqualTo(9));

            // show that the static auto-property acts as expected
            MixinTarget.StaticProperty = 0;
            Assert.That(MixinTarget.StaticProperty, Is.EqualTo(0));
            MixinTarget.StaticProperty = 5648;
            Assert.That(MixinTarget.StaticProperty, Is.EqualTo(5648));

            // show that the static event calls delegate as expected and that the method is called correctly
            var staticCallCount = 0;
            EventHandler<MixinTarget.NestedEventArgs> staticEventHandler = (sender, e) =>
            {
                // note that the implementation code sends typeof(MixinImplementation), but that it is replaced by typeof(MixinTarget)
                Assert.That(sender, Is.EqualTo(typeof(MixinTarget)));
                Assert.That(e.Things, Is.EqualTo(MixinTarget.Attributes.Nothing));
                ++staticCallCount;
            };

            MixinTarget.NestedThingsHappened += staticEventHandler;
            var length = MixinTarget.StaticMethod("What you are is lovely");
            Assert.That(staticCallCount, Is.EqualTo(1));
            Assert.That(length, Is.EqualTo("What you are is lovely".Length));

            MixinTarget.NestedThingsHappened -= staticEventHandler;
            length = MixinTarget.StaticMethod(null);
            Assert.That(staticCallCount, Is.EqualTo(1));
            Assert.That(length, Is.EqualTo(0));

            // play around with a generic nested type
            var nestedTarget = new MixinTarget.NestedGenericType<int, string>(42, "forty-two");
            Assert.That(nestedTarget.Dee, Is.EqualTo(42));
            Assert.That(nestedTarget.Dum, Is.EqualTo("forty-two"));

            // more play, add in generic method with partially closed generic return type
            var wibblyWobbly = target.GetAThing(989);
            Assert.That(wibblyWobbly.Dee, Is.EqualTo("canned spam"));
            Assert.That(wibblyWobbly.Dum, Is.EqualTo(989));
        }
    }
}
