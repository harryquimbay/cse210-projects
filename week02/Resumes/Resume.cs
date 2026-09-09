public class Resume
{
    // Stores the name of the person.
    public string _name = "";

    // Stores the list of jobs in the resume.
    public List<Job> _jobs = new List<Job>();

    // Displays the person's name and all jobs in the resume.
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}