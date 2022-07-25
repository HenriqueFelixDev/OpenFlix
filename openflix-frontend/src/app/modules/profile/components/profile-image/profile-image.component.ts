import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
    selector: 'app-profile-image',
    templateUrl: './profile-image.component.html',
    styleUrls: ['./profile-image.component.scss']
})
export class ProfileImageComponent {
    @Input()
    imageUrl: string = '';

    @Input()
    name?: string;

    @Input()
    isSelected: boolean = false

    @Input()
    showActions: boolean = false

    @Output()
    editClick = new EventEmitter();
    
    @Output()
    deleteClick = new EventEmitter();

    onEditClick(event: MouseEvent) {
        event.stopPropagation()
        this.editClick.emit()
    }

    onDeleteClick(event: MouseEvent) {
        event.stopPropagation()
        this.deleteClick.emit()
    }
}