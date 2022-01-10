
export interface ApplicationFormValues {
    schoolYearId: number;
    schoolId: number | undefined;
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
    hasSibling: string | boolean;
    siblingName?: string;
    siblingSchool?: string;
    primaryParentName: string;
    primaryParentEmail: string;
    primaryParentPhoneNumber: string;
    primaryParentRelationship: string;
    secondaryParentName?: string;
    secondaryParentEmail?: string;
    secondaryParentPhoneNumber?: string;
    secondaryParentRelationship?: string;
}

export class Application implements ApplicationFormValues {
    schoolYearId: number = -1;
    schoolId: number | undefined = -1;
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
    hasSibling: string | boolean = false;
    siblingName?: string = '';
    siblingSchool?: string = '';
    primaryParentName: string = '';
    primaryParentEmail: string = '';
    primaryParentPhoneNumber: string = '';
    primaryParentRelationship: string = '';
    secondaryParentName?: string = '';
    secondaryParentEmail?: string = '';
    secondaryParentPhoneNumber?: string = '';
    secondaryParentRelationship?: string = '';

    constructor(schoolYearId: number){
        this.schoolYearId = schoolYearId;
    }

}