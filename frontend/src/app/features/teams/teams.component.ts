import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators, ReactiveFormsModule, FormControl } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatTabsModule } from '@angular/material/tabs';
import { TeamsService } from '../../core/services/teams.service';


@Component({
  selector: 'app-teams',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatInputModule, MatButtonModule, MatTabsModule],
  templateUrl: './teams.component.html',
  styleUrl: './teams.component.scss'
})
export class TeamsComponent {
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private teamsService: TeamsService,
  ) {
    this.form = this.fb.group({
      teams: this.fb.array([
        this.createTeamGroup(),
        this.createTeamGroup()
      ])
    });
  }

  get teams(): FormArray {
    return this.form.get('teams') as FormArray;
  }

  createTeamGroup(): FormGroup {
    return this.fb.group({
      name: ['', Validators.required],
      players: this.fb.array([
        this.fb.control('', Validators.required),
        this.fb.control('', Validators.required),
        this.fb.control('', Validators.required),
        this.fb.control('', Validators.required),
      ])
    });
  }

  getPlayers(teamIndex: number): FormArray<FormControl> {
    return this.teams.at(teamIndex).get('players') as FormArray<FormControl>;
  }

  submit() {
    if (this.form.valid) {
      const teams = this.form.value.teams;
      this.teamsService.saveTeams(teams).subscribe({
        next: () => {
          // Mostra messaggio, naviga avanti, ecc.
          alert('API completata');
        },
        error: err => {
          // Gestione errore
          alert('Errore nel salvataggio!');
          console.error(err);
        }
      });
    }
  }
}