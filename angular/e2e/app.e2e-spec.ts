import { TodoTemplatePage } from './app.po';

describe('Todo App', function() {
  let page: TodoTemplatePage;

  beforeEach(() => {
    page = new TodoTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
