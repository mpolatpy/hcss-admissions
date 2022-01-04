import React, { useState } from 'react';
import Box from '@mui/material/Box';
import Stepper from '@mui/material/Stepper';
import Step from '@mui/material/Step';
import StepLabel from '@mui/material/StepLabel';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import { Application } from '../../models/ApplicationFormModels';
import StepContents from './steps/StepContents';
import { Form, Formik } from 'formik';
import { validationSchema } from './validation/ValidationSchema';
import agent from '../../api/agent';

const steps = ['Application Details', 'Student', 'Parent(s)', 'Other Details', 'Review and Submit'];

export default function SteppedForm() {
  const [activeStep, setActiveStep] = useState(0);
  const currentValidationSchema = validationSchema[activeStep];
  const isLastStep = activeStep === steps.length - 1;
  const schoolYear = '21-22';

  function _sleep(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }

  async function _submitForm(values: Application, actions: any) {
    
    try{
      await agent.Applications.create(values)
      actions.setSubmitting(false);
      setActiveStep(activeStep + 1);
    } catch (e) {
      actions.setSubmitting(false);
      console.log(e);
    } 
    
  }

  function _handleSubmit(values: Application, actions: any) {
    if (isLastStep) {
      _submitForm(values, actions);
    } else {
      setActiveStep(activeStep + 1);
      actions.setTouched({});
      actions.setSubmitting(false);
    }
  }

  const handleBack = () => {
    setActiveStep((prevActiveStep) => prevActiveStep - 1);
    window.scrollTo(0, 0);
  };

  const handleReset = () => {
    setActiveStep(0);
  };

  return (
    <Box sx={{ width: '100%' }}>
      <Stepper activeStep={activeStep} alternativeLabel>
        {steps.map((label, index) => (
          <Step key={label} >
            <StepLabel >{label}</StepLabel>
          </Step>
        )
        )}
      </Stepper>
      {activeStep === steps.length ? (
        <>
          <Typography sx={{ mt: 2, mb: 1 }}>
            All steps completed - you&apos;re finished
          </Typography>
          <Box sx={{ display: 'flex', flexDirection: 'row', pt: 2 }}>
            <Box sx={{ flex: '1 1 auto' }} />
            <Button onClick={handleReset}>Edit</Button>
            <Button>Submit</Button>
          </Box>
        </>
      ) : (
        <Formik
          initialValues={new Application(schoolYear)}
          onSubmit={_handleSubmit}
          validationSchema={currentValidationSchema}
        >
          {({ isSubmitting, values, dirty, isValid }) => (
            <Form autoComplete='off'>
              <StepContents
                step={activeStep}
              />
              <Box sx={{ display: 'flex', flexDirection: 'row', pt: 2 }}>
                <Button
                  color="inherit"
                  variant="outlined"
                  disabled={activeStep === 0}
                  onClick={handleBack}
                  sx={{ mr: 1 }}
                >
                  Back
                </Button>
                <Box sx={{ flex: '1 1 auto' }} />
                {
                  isLastStep && (
                    <Button onClick={handleReset}>Edit</Button>
                  )
                }
                <Button
                  disabled={isSubmitting}
                  variant="contained"
                  type="submit"
                >
                  {activeStep === steps.length - 1 ? 'Finish' : 'Next'}
                </Button>
              </Box>
              <button type="button" onClick={() => console.log(values, isValid, dirty)}>values</button>
            </Form>
          )
          }
        </Formik>
      )}
      <button onClick={() => console.log(activeStep)}>Active Step</button>
    </Box>
  );
}
