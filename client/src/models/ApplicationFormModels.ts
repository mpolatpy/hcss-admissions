
export interface ApplicationFormValues {
    schoolYear: string;
    school: string;
    grade: string;
    agreeToTerms: boolean;
    howDidYouHear: string | null;
    firstName: string;
    lastName: string;
    middleName?: string;
    dob: Date | null;
    streetAddress: string;
    city: string;
    state: string;
    zipcode: string;
    gender: string;
    currentSchool: string;
    currentGrade: string;
    hasSibling: boolean;
    siblingName?: string;
    siblingSchool?: string;
    primaryParentName: string;
    primaryParentEmail: string;
    primaryParentPhone: string;
    primaryParentRelationship: string;
    secondaryParentName?: string;
    secondaryParentEmail?: string;
    secondaryParentPhone?: string;
    secondaryParentRelationship?: string;
}

export class Application implements ApplicationFormValues {
    schoolYear: string;
    school: string = '';
    grade: string = '';
    agreeToTerms: boolean = false;
    howDidYouHear: string | null = null;
    firstName: string = '';
    lastName: string = '';
    middleName?: string = '';
    dob: Date | null = null;
    streetAddress: string = '';
    city: string = '';
    state: string = '';
    zipcode: string = '';
    gender: string = '';
    currentSchool: string = '';
    currentGrade: string = '';
    hasSibling: boolean = false;
    siblingName?: string = '';
    siblingSchool?: string = '';
    primaryParentName: string = '';
    primaryParentEmail: string = '';
    primaryParentPhone: string = '';
    primaryParentRelationship: string = '';
    secondaryParentName?: string = '';
    secondaryParentEmail?: string = '';
    secondaryParentPhone?: string = '';
    secondaryParentRelationship?: string = '';

    constructor(schoolYear: string){
        this.schoolYear = schoolYear;
    }

}