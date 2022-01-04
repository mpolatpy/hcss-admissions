import React from 'react';
import ApplicationDetails from './ApplicationDetails';
import StudentInfo from './StudentInformation';
import Typography from '@mui/material/Typography';
import ReviewApplication from './ReviewApplication';
import ParentDetails from './ParentDetails';
import OtherDetails from './OtherDetails';

interface Props {
    step: number;
}

export default function StepContents({ step }: Props) {

    switch (step) {
        case 0:
            return (
                <ApplicationDetails/>
            );
        case 1:
            return (
                <StudentInfo />
            );
        case 2:
            return(
                <ParentDetails />
            )
        case 3:
            return (
                <OtherDetails />
            )
        default:
            return (
                <>
                    <Typography sx={{ mt: 2, mb: 1 }}>Step {step + 1}</Typography>
                    <ReviewApplication />
                </>
            )
    }
    
}