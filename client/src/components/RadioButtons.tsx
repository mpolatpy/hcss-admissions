import React, { ChangeEvent, useState } from 'react';
import { useField } from 'formik';
import Radio from '@mui/material/Radio';
import RadioGroup from '@mui/material/RadioGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import FormControl from '@mui/material/FormControl';
import FormLabel from '@mui/material/FormLabel';
import FormHelperText from '@mui/material/FormHelperText';
import { Typography } from '@mui/material';

interface Props {
    options: string[] | number[] | boolean[];
    labels: string[];
    legend: string;
    name: string;
    description?: string;
    row?: boolean | undefined;
}

const RadioButtons = (props: Props) => {
    const { options, labels, legend, name, row, description } = props;
    const [field, meta] = useField(name);


    return (
        <FormControl error={meta.touched && !!meta.error} component="fieldset">
            <FormLabel component="legend">{legend}</FormLabel>
            {
                description && (
                    <Typography mt={1} variant="caption">{description}</Typography>
                )
            }
            <RadioGroup
                row={row}
                aria-label={legend}
                {...field}
                {...props}
            >
                {
                    options.map((option, i) => (
                        <FormControlLabel key={i} value={option} control={<Radio />} label={labels[i]} />
                    ))
                }
            </RadioGroup>
            {meta.touched && meta.error ? (
                <FormHelperText color="red">{meta.error}</FormHelperText>
            ) : null}
            
        </FormControl>
    );
}

export default RadioButtons;
