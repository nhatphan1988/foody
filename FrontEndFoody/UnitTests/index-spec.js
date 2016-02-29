//describe('angularjs homepage todo list', function () {
//    it('should add a todo', function () {
//        browser.get('https://angularjs.org');

//        element(by.model('todoList.todoText')).sendKeys('write first protractor test');
//        element(by.css('[value="add"]')).click();

//        var todoList = element.all(by.repeater('todo in todoList.todos'));
//        expect(todoList.count()).toEqual(3);
//        expect(todoList.get(2).getText()).toEqual('write first protractor test');

//        // You wrote your first test, cross it off the list
//        todoList.get(2).element(by.css('input')).click();
//        var completedAmount = element.all(by.css('.done-true'));
//        expect(completedAmount.count()).toEqual(2);
//    });
//});

it('should load and compile correct template', function () {
    browser.get('http://localhost:51571/index.html');
    element(by.linkText('Moby: Ch1')).click();
    var content = element(by.css('[ng-view]')).getText();
    expect(content).toMatch(/controller\: ChapterController/);
    expect(content).toMatch(/Book Id\: Moby/);
    expect(content).toMatch(/Chapter Id\: 1/);

    element(by.partialLinkText('Scarlet')).click();

    content = element(by.css('[ng-view]')).getText();
    expect(content).toMatch(/controller\: BookController/);
    expect(content).toMatch(/Book Id\: Scarlet/);
});