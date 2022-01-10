import * as Yup from 'yup';

const phoneRegExp = /^((\\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/

export const validationSchema = [
    Yup.object({
        schoolId: Yup.string().required('Please select the school'),
        schoolYearId: Yup.string().required('Select which school year you want to apply'),
        grade: Yup.string().required('Please select a grade level'),
    }),
    Yup.object({
        firstName: Yup.string().required('This is a required field'),
        lastName: Yup.string().required('This is a required field'),
        gender: Yup.string().required('This is a required field'),
        currentGrade: Yup.string().required('This is a required field'),
        currentSchool: Yup.string().required('This is a required field'),
        streetAddress: Yup.string().required('This is a required field'),
        state: Yup.string().required('This is a required field'),
        city: Yup.string().required('This is a required field'),
        dob: Yup.date()
                .nullable()
                .required("Please enter a valid date"),
        zipcode: Yup.string().required('This is a required field'),
    }),
    Yup.object({
        primaryParentName: Yup.string().required('This is a required field'),
        primaryParentEmail: Yup.string().required('This is a required field').email('Enter a valid email'),
        primaryParentPhoneNumber: Yup.string().required('This is a required field').matches(phoneRegExp, 'Phone number is not valid'),
        primaryParentRelationship: Yup.string().required('This is a required field'),
        secondaryParentName: Yup.string(),
        secondaryParentEmail: Yup.string().email('Enter a valid email'),
        secondaryParentPhoneNumber: Yup.string().matches(phoneRegExp, 'Phone number is not valid'),
        secondaryParentRelationship: Yup.string(),
    })
]