namespace Diary;

public class Tasks
{ 
    public int Id { get; private set; }
    public string Title { get; private set; } 
    public string Description { get; private set; }
    public DateTime DateTime { get; private set; }

    public Tasks(int id, string title, string description, DateTime datetime)
    {
        Id = id;
        Title = title;
        Description = description;
        DateTime = datetime;
    }

    public void SetNewId(int id)
    {
        Id = id;
    }

    public override string ToString()
    {
        return $"\n № {Id} \n Название задачи: {Title} \n Описание: {Description} \n Дата: {DateTime}";
    }
}