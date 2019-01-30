using Mimick;

namespace MimickSample
{
    /// <summary>
    /// A model class which introduces the property-changed interface.
    /// </summary>
    [PropertyChanged]
    public class SampleModel
    {
        /// <summary>
        /// Gets or sets the identity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        [IgnoreChange]
        public object Tag { get; set; }
    }
}