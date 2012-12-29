var viewModel = {
    todos: ko.observableArray([]),

    loadToDos: function () {
        "use strict";
        /// <summary>load all To Dos</summary>
        var self = this;
        $.ajax({
            url: toDoSettings.url,
            dataType: 'json',
            async: false,
            success: function (data) {
                self.todos.removeAll();
                $.each(data, function (index, item) {
                    self.todos.push(new Model(item));
                });
            }
        });
    },
    add: function (parameters) {
        /// <summary>add a new To Do</summary>
        'use strict';
        var form = $('#AddToDoForm'),
            data = this.getToDoFromForm(form),
            todo = new Model(data);

        if (!form.valid()) {
            return;
        }
        
        $.ajax({
            url: toDoSettings.url,
            type: 'POST',
            dataType: 'json',
            data: todo,
            async: false,
            success: function () {
                viewModel.loadToDos();
            }
        });

        form.get(0).reset();
        $('#AddToDo').modal('hide');
    },
    remove: function (item, evt) {
        /// <summary>delete To Do</summary>
        'use strict';
        $.ajax({
            url: toDoSettings.url + item.Id(),
            type: 'DELETE',
            dataType: 'json',
            async: false,
            success: function () {
                viewModel.loadToDos();
            }
        });
    },
    done: function (item, evt) {
        /// <summary>set a To Do as complete</summary>
        /// <param name="item" type="'us"></param>
        /// <param name="evt" type="Object"></param>
        'use strict';
        item.Completed(!item.Completed());
        $.ajax({
            url: toDoSettings.url + item.Id(),
            type: 'PUT',
            dataType: 'json',
            data: item,
            async: false,
            success: function () {
                viewModel.loadToDos();
            }
        });
    },
    getToDoFromForm: function (form) {
        /// <summary>get to do from form</summary>
        /// <param name="form" type="Object">form with data</param>
        /// <returns type="Object">a To Do based on form data</returns>
        'use strict';
        form = $(form);
        var todo = {
            id: 0,
            Description: '',
            Completed: false,
            OpenDateSupport: '',
            CloseDateSupport: '',
            OpenDate: '"2012-12-09T18:15:56.713"',
            CloseDate: ''
        };
        form.find('input[type!=submit]').each(function () {
            var key = this.id,
                value = $(this).val();

            todo[key] = value;
        });
        return todo;
    },
    filterByProperty: function (prop, val) {
        'use strict';
        var self = this,
            result = [];
        $(viewModel.todos()).each(function (index, item) {
            var exists = $(item).attr(prop) !== undefined,
                currentValue;
            if (exists) {
                currentValue = $(item).attr(prop)();
                if (currentValue === val) {
                    result.push(item);
                }
            }
        });

        return result;
    }
};