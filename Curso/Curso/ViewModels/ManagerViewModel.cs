
namespace Curso.ViewModels
{
    /// <summary>
    /// The manager view model.
    /// </summary>
    public class ManagerViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public int Age { get; set; }

        
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerViewModel"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="age">
        /// The age.
        /// </param>
        public ManagerViewModel(int id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerViewModel"/> class.
        /// </summary>
        public ManagerViewModel() {}
    }
}