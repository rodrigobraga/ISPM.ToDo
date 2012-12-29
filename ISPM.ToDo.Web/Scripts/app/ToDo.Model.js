function Model(todo) {
    this.Id = ko.observable(todo.Id);
    this.Description = ko.observable(todo.Description);
    this.Completed = ko.observable(todo.Completed);
    this.OpenDateSupport = ko.observable(todo.OpenDateSupport);
    this.CloseDateSupport = ko.observable(todo.CloseDateSupport);
    this.OpenDate = ko.observable(todo.OpenDate);
    this.CloseDate = ko.observable(todo.CloseDate);
}