namespace Entities;
class Person
{
    public string Name { get; set; }
    public int Id { get; set; }
    public Person()
    {

    }
    public Person(int id, string name)
    {
        Name = name;
        Id = id;
    }

    public override int GetHashCode()
    {
        const int prime = 31;
        int hashCode = Name.GetHashCode() ^ prime;
        hashCode = hashCode * Id.GetHashCode();
        return hashCode;
    }
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is Person other)
        {
            if (!this.Id.Equals(other.Id))
                return false;
            if (!this.Name.Equals(other.Name))
                return false;

            return true;
        }
        else
            return false;
    }
    public override string ToString()
    {
        return $"Name={Name},Id= {Id}";
        //return this.GetType().FullName;
    }
}
