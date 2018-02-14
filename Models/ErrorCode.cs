namespace TodoAppRestAPI.Models
{
    public enum ErrorCode
    {
        TodoItemNameAndNotesrequired,
        TodoItemAlreadyExists,
        CouldNotCreateItem,
        ItemNotFound,
        CouldNotUpdateItem,
        CouldNotDeleteItem
    }
}