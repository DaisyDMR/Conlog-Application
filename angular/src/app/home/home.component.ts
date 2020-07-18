import { Component, Injector, ChangeDetectionStrategy, OnInit, inject } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    TaskServiceProxy as _taskService,
    GetTasksOutput,
    TaskDto,
    GetActiveTaskCountOutput,
    UpdateTaskInput,
    SessionServiceProxy,
    UserLoginInfoDto
} from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { state } from '@angular/animations';

@Component({
    templateUrl: './home.component.html',
    animations: [appModuleAnimation()],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent extends AppComponentBase {
    activeTasks: GetTasksOutput;
    activeCount: GetActiveTaskCountOutput;
    newTask: TaskDto = new TaskDto();
    user: UserLoginInfoDto = new UserLoginInfoDto();

    constructor(injector: Injector, private taskServiceProxy: _taskService, private _sessionService: SessionServiceProxy) {
        super(injector);
    }

    ngOnInit(): void {
        this.getCount();
        this.getTasks();
        this._sessionService.getCurrentLoginInformations().pipe(
            finalize(() => {
            })
        ).subscribe((result) => {
            this.user = result.user;
            console.log(this.user);
        });;
    }

    getCount(): void {
        this.taskServiceProxy.getActiveTaskCount().pipe(
            finalize(() => {
            })
        ).subscribe((result) => {
            this.activeCount = result;
        });
    }

    getTasks(): void {
        this.taskServiceProxy
            .getTasks(1, this.user.id)
            .pipe(
                finalize(() => {
                })
            )
            .subscribe((result) => {
                this.activeTasks = result;
            });
    }

    markComplete(task: TaskDto): void {
        const body = new UpdateTaskInput();
        body.assignedPersonId = task.assignedPersonId;
        body.taskId = task.id;
        body.state = 2;

        this.taskServiceProxy
            .updateTask(body)
            .pipe(
                finalize(() => {
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.getCount();
                this.getTasks();
            });
    }

    addTask(): void {
        console.log(this.newTask);
        this.newTask.assignedPersonId = this.user.id;
        this.newTask.state = 1;
        this.newTask.id = 0;
        this.taskServiceProxy
            .createTask(this.newTask)
            .pipe(
                finalize(() => {
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.newTask.description = "";
                this.getCount();
                this.getTasks();
            });
    }
}
